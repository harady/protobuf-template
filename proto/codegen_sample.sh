#!/bin/bash

#================================
# codegen2_all
# c:クリーンビルド
# p:終了時にポーズ
# 例：
# codegen_sample.sh cp
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
  rm -rf output_sample
fi

# 出力サンプル
ruby codegen.rb -i codegen_sample.yml

# 一時停止
if [[ "$param" == *p* ]]; then
  echo "total $SECONDS [sec]"
  read -p "Press [Enter] key to resume."
fi
