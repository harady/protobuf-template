# encoding: utf-8
require "optparse"
require "./code_generator"
require "yaml"

STDOUT.sync = true

#============================================================
# メイン処理.
#============================================================
def main()
  generator = CodeGenerator.new()
  yml_path = "codegen.yml"

  # オプションを読み込む.
  opt = OptionParser.new
  opt.on("-f", "--force", "強制的に生成する") {
    generator.is_force_update = true
  }
  opt.on("-i", "--input=VALUE", "yamlファイルを指定する") { |val|
    yml_path = val
  }
  opt.parse(ARGV)

  # 指定されたymlファイルを読み込む.
  data = open(yml_path, "r") { |f| YAML.load(f) }

  # コード生成処理を実行.
  generator.generate_recursive(data: data)
end

main()
