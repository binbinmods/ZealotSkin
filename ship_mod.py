import os
import shutil
from pathlib import Path

def copy_directory(source_dir: str, destination_dir: str):
    source_path = Path(source_dir)
    destination_path = Path(destination_dir)
        
    destination_path.mkdir(parents=True, exist_ok=True)
    for item in source_path.iterdir():
        destination_filepath = destination_path / item.name
        if item.is_dir():
            if destination_filepath.exists():                
                shutil.rmtree(destination_filepath)
            shutil.copytree(item, destination_filepath)
        else:
            shutil.copy2(item, destination_filepath)
            
    print(f"Directory Copied")


def zip_mods():
    download_dir = os.path.expanduser("~/Downloads")
    output_name = f"{download_dir}/Mod Zips/{mod_dir}"

    print("zipping to Mod Zips")
    zip_dir = f"{script_dir}/{mod_dir}"
    shutil.make_archive(output_name, 'zip', zip_dir)

    print("zipping to local")
    output_name = f"{script_dir}/{mod_dir}"
    shutil.make_archive(output_name, 'zip', zip_dir)


if __name__ == "__main__":  
    mod_dir = "ZealotSkin"
    # config_dir = f"{mod_dir}Configs"    
    content_destination_dir = mod_dir
    print(content_destination_dir)
    script_dir = os.path.dirname(os.path.abspath(__file__))
    print(script_dir)
    
    # Copy to Local Game
    source = f"{script_dir}/{mod_dir}/BepInEx/config/Obeliskial_importing/{mod_dir}"
    print(source)
    bepinex_dir = os.path.abspath(os.path.join(script_dir, '..', '..', '..'))
    destination = f"{bepinex_dir}/config/Obeliskial_importing/{content_destination_dir}"
    print(destination)
    copy_directory(source, destination)

    # # Copy to Local Mod folder to zip
    # mod_destination = f"{script_dir}/{mod_dir}/BepInEx/config/Obeliskial_importing/{content_destination_dir}"
    # copy_directory(source, mod_destination)

    zip_mods()