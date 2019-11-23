@echo off

copy D:\git_dir\test_all\proto\client_game.proto 	protos\
copy D:\git_dir\test_all\proto\cmd_def.proto 	protos\
copy D:\git_dir\test_all\proto\error_code.proto 	protos\
copy D:\git_dir\test_all\proto\login.proto 	protos\
copy D:\git_dir\test_all\proto\user.proto 	protos\
cd protos

for %%i in (*.proto) do (
    protoc.exe --csharp_out=../../Assets/ProtobuMsg/ %%i
    echo From %%i To %%~ni.cs Successfully!  
)


pause