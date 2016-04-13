
namespace Aura
{
    public class SettingsViewModel
    {
        //public string DAPathContent => Settings.DarkAgesPath;
        //public string DAFolderContent => Settings.DataPath;
        private string daPathContent;
        public string DAPathContent
        {
            get
            {
                return Settings.DarkAgesPath;
            }
            set
            {
                daPathContent = Settings.DarkAgesPath;
            }
        }
        private string daFolderContent;
        public string DAFolderContent
        {
            get
            {
                return Settings.DataPath;
            }
            set
            {
                daFolderContent = Settings.DataPath;
            }
        }

    }
}
