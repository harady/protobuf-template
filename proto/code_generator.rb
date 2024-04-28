# encoding: utf-8
require "active_support/inflector"
require "fileutils"
require "parallel"

#====================================================================
# テンプレートからコードを生成する.
#====================================================================
class CodeGenerator
  attr_accessor :message
  attr_accessor :protoc_path
  attr_accessor :protoc_plugin_path
  attr_accessor :src_base_path
  attr_accessor :src_path_pattern
  attr_accessor :template_base_path
  attr_accessor :template_path
  attr_accessor :file_suffix
  attr_accessor :out_base_path
  attr_accessor :out_dir_path
  attr_accessor :is_editable
  attr_accessor :is_force_update
  attr_accessor :file_name_case

  def initialize
    @message = ""
    @protoc_path = ""
    @protoc_plugin_path = ""
    @src_base_path = ""
    @src_path_pattern = ""
    @template_base_path = ""
    @template_path = ""
    @file_suffix = ""
    @out_base_path = ""
    @out_dir_path = ""
    @is_editable = false
    @is_force_update = false
    @target_content_pattern = nil
    @file_name_case = ""
  end

  def actual_src_path_pattern
    "#{@src_base_path}#{@src_path_pattern}"
  end

  def actual_template_path
    "#{@template_base_path}#{@template_path}"
  end

  def actual_out_dir_path
    "#{@out_base_path}#{@out_dir_path}"
  end

  #============================================================
  # コード生成実行処理.
  #============================================================
  def generate_recursive(data:)
    generator = clone()
    generator.setup_by_data(data: data)

    generator.show_message()

    items = data.dig("items")
    if items.nil?
      generator.generate_inner()
    else
      items.each do |item|
        generator.generate_recursive(data: item)
      end
    end
  end

  #============================================================
  # dataオブジェクトを使用してこのジェネレーターのセットアップを行う.
  #============================================================
  def setup_by_data(data:)
    setup(
      message: data.dig("message"),
      protoc_path: data.dig("protoc_path"),
      protoc_plugin_path: data.dig("protoc_plugin_path"),
      src_base_path: data.dig("src_base_path"),
      src_path_pattern: data.dig("src_path_pattern"),
      template_base_path: data.dig("template_base_path"),
      template_path: data.dig("template_path"),
      file_suffix: data.dig("file_suffix"),
      out_base_path: data.dig("out_base_path"),
      out_dir_path: data.dig("out_dir_path"),
      is_editable: data.dig("is_editable"),
      is_force_update: data.dig("is_force_update"),
      target_content_pattern: data.dig("target_content_pattern"),
      file_name_case: data.dig("file_name_case"),
    )
  end

  #============================================================
  # このジェネレーターのセットアップを行う.
  #============================================================
  def setup(
    message: nil,
    protoc_path: nil,
    protoc_plugin_path: nil,
    src_base_path: nil,
    src_path_pattern: nil,
    template_base_path: nil,
    template_path: nil,
    file_suffix: nil,
    out_base_path: nil,
    out_dir_path: nil,
    is_editable: nil,
    is_force_update: nil,
    target_content_pattern: nil,
    file_name_case: nil
  )
    self.message = message if !message.nil?
    self.protoc_path = protoc_path if !protoc_path.nil?
    self.protoc_plugin_path = protoc_plugin_path if !protoc_plugin_path.nil?
    self.src_base_path = src_base_path if !src_base_path.nil?
    self.src_path_pattern = src_path_pattern if !src_path_pattern.nil?
    self.template_base_path = template_base_path if !template_base_path.nil?
    self.template_path = template_path if !template_path.nil?
    self.file_suffix = file_suffix if !file_suffix.nil?
    self.out_base_path = out_base_path if !out_base_path.nil?
    self.out_dir_path = out_dir_path if !out_dir_path.nil?
    self.is_editable = is_editable if !is_editable.nil?
    self.is_force_update = is_force_update if !is_force_update.nil?
    self.target_content_pattern = target_content_pattern if !target_content_pattern.nil?
    self.file_name_case = file_name_case if !file_name_case.nil?
    self
  end

  #====================================================================
  # テンプレートからコードを生成する.
  #====================================================================
  def generate_inner()
    # 出力先フォルダがなければ生成.
    FileUtils.mkdir_p(actual_out_dir_path)
    src_file_paths = Dir.glob(actual_src_path_pattern)

    # src_file_paths.each do |src_file_path|
    #   generate_code(src_file_path: src_file_path)
    # end
    Parallel.each(src_file_paths, in_threads: 10) do |src_file_path|
      generate_code(src_file_path: src_file_path)
    end
    self
  end

  def show_message()
    puts message if !message.nil?
  end

  #====================================================================
  # テンプレートからコードを生成する.
  #====================================================================
  def generate_code(
    src_file_path:
  )
    file_prefix = File.basename(src_file_path, ".*").camelize

    if file_name_case == "Pascal"
      file_prefix = file_prefix.camelize(:upper)
    elsif file_name_case == "Camel"
      file_prefix = file_prefix.camelize(:lower)
    elsif file_name_case == "Snake"
      file_prefix = file_prefix.underscore
    elsif file_name_case == "UpperSnake"
      file_prefix = file_prefix.underscore.upcase
    else
      file_prefix = file_prefix.camelize(:upper)
    end

    out_file_path = "#{actual_out_dir_path}/#{file_prefix}#{file_suffix}"

    # 更新不要ならスキップ.
    skip = false
    if File.exist?(out_file_path)
      skip = true
      # 編集不能なコードはソース、テンプレートの更新あったらスキップしない.
      if !is_editable
        skip &= (File.mtime(src_file_path) < File.mtime(out_file_path))
        skip &= (File.mtime(actual_template_path) < File.mtime(out_file_path))
      end
    end
    skip = false if is_force_update
    return if skip

    # コード生成コマンド実行.
    command = "#{protoc_path} --proto_path=#{src_base_path}"
    command += " --csharp-template_out=template=#{actual_template_path},"
    if !(file_name_case.nil? || file_name_case.empty?)
      command += "outFileCase=#{file_name_case},"
    end
    command += "fileSuffix=#{file_suffix}:#{actual_out_dir_path} "
    command += "--plugin=#{protoc_plugin_path} #{src_file_path}"
    `#{command}`

    if File.exist?(out_file_path)
      puts "generate_innerCode Source:#{out_file_path}\n"
    end
  end
end
