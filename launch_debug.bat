@echo off
chcp 65001
setlocal EnableDelayedExpansion
set app=bin\Mao_Good_Transite_x64d.dll
$(ADDITIONAL_PATH)
start "" dotnet "%app%" -video_app auto -video_refresh 0 -video_debug 0 -video_mode -1 -video_width 1920 -video_height 1080 -video_resizable 1 -video_fullscreen 0 -video_vsync 0 -sound_app auto -data_path ../data/ -extern_plugin FbxImporter,GLTFImporter,FbxExporter -console_command "config_autosave 0 && world_load \"Mao_Good_Transite\""
