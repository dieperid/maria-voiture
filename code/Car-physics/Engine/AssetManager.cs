using System;
using System.Collections.Generic;
using System.IO;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace SFML_Engine
{
    internal class AssetManager
    {
        Dictionary<string, Texture> _textures = new Dictionary<string, Texture>(); //Contains loaded textures
        Dictionary<string, Font> _fonts = new Dictionary<string, Font>(); //Contains loaded fonts

        /// <summary>
        /// Recursively load files from root directory
        /// </summary>
        public void Loadfiles(string path)
        {
            FileInfo fi;
            string[] paths = Directory.GetFiles(path);

            foreach(string p in paths)
            {
                fi = new FileInfo(p);
                if (fi.Extension.ToLower() == ".ttf")
                {
                    _fonts.Add(fi.Name, new Font(fi.FullName));
                }
                if (fi.Extension.ToLower() == ".png" || fi.Extension.ToLower() == ".jpg")
                {
                    _textures.Add(fi.Name, new Texture(fi.FullName));
                }
            }

            paths = Directory.GetDirectories(path);
            if(path.Length > 0)
            {
                foreach(string p in paths) { Loadfiles(p); }
            }
        }

        /// <summary>
        /// Get texture
        /// </summary>
        /// <param name="name"> Texture's file name </param>
        /// <returns> Texture </returns>
        public Texture GetTexture(string name)
        {
            Texture tex = null;
            _textures.TryGetValue(name, out tex);

            if(tex == null)
            {
                LogHandler.GetInstance().AddLog($"[ASSETMANAGER][GETTEXTURE-ERROR] {name} doesn't exist");
                return new Texture(10,10);
            }

            return tex;
        }

        /// <summary>
        /// Get font
        /// </summary>
        /// <param name="name"> Font's file name </param>
        /// <returns> Font </returns>
        public Font GetFont(string name)
        {
            Font font = null;
            _fonts.TryGetValue(name, out font);

            if (font == null)
            {
                LogHandler.GetInstance().AddLog($"[ASSETMANAGER][GETTEXTURE-ERROR] {name} doesn't exist");
            }

            return font;
        }
    }
}
