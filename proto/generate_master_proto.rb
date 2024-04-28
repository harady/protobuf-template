#===========================================================
# .
#===========================================================

class String
  def to_pascal()
    self.split("_").map{|w| w[0] = w[0].upcase; w}.join
  end
end

# 引数読み込み.
templateFile = ARGV[0]
memberProtoListFile = ARGV[1]
startNumber = ARGV[2].to_i

file = File.open(templateFile)
result = file.read  # 全て読み込む
file.close

file = File.open(memberProtoListFile)
lines = file.readlines
file.close

importsStr = ""
lines.each{|line|
	importStr = "import \"%s\";\n" % line.chomp
	importsStr << importStr
}
importsStr.chomp!

fieldsStr = ""
fieldNumber = startNumber
lines.each{|line|
	name = line.match(/.+\/.+\/(.+)\.proto/)[1]
	typeName = "repeated " + name.to_pascal() + "Data"
	fieldName = name + "s"
	importStr = "    %s %s" % [typeName, fieldName]
	importStr = importStr.ljust(70) + "= %s; // .\n" % fieldNumber.to_s.rjust(3)
	fieldsStr << importStr
	fieldNumber += 1
}
fieldsStr.chomp!

result.sub!("\<imports\>", importsStr)
result.sub!("\<fields\>", fieldsStr)

STDOUT.write result


