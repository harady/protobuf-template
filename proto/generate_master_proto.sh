#!/bin/sh


# ================================================
# master.proto を生成する.
# ================================================
MasterFilePath="master.txt"
rm -f ${MasterFilePath}

grep -l "tag:is_master" table/*/* > ${MasterFilePath}
ruby generate_master_proto.rb "template/template_master.txt" ${MasterFilePath} 2 > "data/master.proto"
rm -f ${MasterFilePath}


# ================================================
# client_master.proto を生成する.
# ================================================
ClientMasterFilePath="client_master.txt"
rm -f ${ClientMasterFilePath}

grep -l "tag:is_client_master" table/*/* > ${ClientMasterFilePath}
ruby generate_master_proto.rb "template/template_client_master.txt" ${ClientMasterFilePath} 1 > "data/client_master.proto"
rm -f ${ClientMasterFilePath}


# ================================================
# user_update.proto を生成する.
# ================================================
ClientUserFilePath="client_user.txt"
rm -f ${ClientUserFilePath}

grep -l "tag:is_client_user_data" table/*/* > ${ClientUserFilePath}
ruby generate_master_proto.rb "template/template_user_update.txt" ${ClientUserFilePath} 2 > "data/user_update.proto"
rm -f ${ClientUserFilePath}

