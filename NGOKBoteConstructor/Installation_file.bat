certutil -user -addstore "TrustedPublisher" "files\NGOKBoteConstructor.cer"

echo off
start /wait files\NGOKBoteConstructor.appx /Param