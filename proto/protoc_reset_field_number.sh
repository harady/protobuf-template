#!/bin/sh

protoc=bin/protoc
service_name=my-service

#============================================================
# Field Numberを再割り当て.
#============================================================
echo "Field Numberを再割り当て."

data_filepaths=$(find ./data -type f -name "*.proto")
table_filepaths=$(find ./table -type f -name "*.proto")
service_filepaths=$(find ./service -type f -name "*.proto")
filepaths=(${data_filepaths} ${table_filepaths} ${service_filepaths})

for filepath in ${filepaths[*]} ; do
    echo ">>> ${filepath}"
    tmp_filepath=${filepath}_tmp
    awk -v 'ORS=\r\n' '/[ \t]+[^ \t]+[ \t]+[^ \t]+[ \t]+=.+;/{sub(/=.*;/,sprintf("=%4s;",++i))}{print} /^message/{i=0}' ${filepath} > ${tmp_filepath}
    mv ${tmp_filepath} ${filepath}
done
read -p "Press [Enter] key to resume."
