#!/bin/bash

#================================
# codegen_all
# c:クリーンビルド
# p:終了時にポーズ
# 例：
# codegen_all.sh cp
#================================

SECONDS=0

# 引数セットアップ.
if [ $# = 0 ]; then
    param=""
else
    param="$1"
fi

# 出力フォルダクリーン
if [[ "$param" == *c* ]]; then
  rm -rf output
fi

# サーバー側
ruby codegen.rb -i codegen_server_cs.yml

# Unity側
ruby codegen.rb -i codegen_unity_cs.yml

# マスターデータ側
sh protoc_sheet.sh

# 一時停止
if [[ "$param" == *p* ]]; then
  echo "total $SECONDS [sec]"
  read -p "Press [Enter] key to resume."
fi
