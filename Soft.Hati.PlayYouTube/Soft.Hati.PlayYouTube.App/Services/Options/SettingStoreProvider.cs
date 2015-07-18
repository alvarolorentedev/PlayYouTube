using Microsoft.VisualStudio.Settings;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Settings;

namespace Soft.Hati.PlayYouTube.App.Services.Options
{
    class SettingStoreProvider
    {
        private readonly WritableSettingsStore userSettingsStore;
        private readonly string collection;

        public SettingStoreProvider(string collection)
        {
            this.collection = collection;
            SettingsManager settingsManager = new ShellSettingsManager(ServiceProvider.GlobalProvider);
            userSettingsStore = settingsManager.GetWritableSettingsStore(SettingsScope.UserSettings);
        }

        public bool Exist(string propertyName)
        {
            return userSettingsStore.PropertyExists(collection, propertyName);
        }

        public string Get(string propertyName)
        {
            return userSettingsStore.GetString(collection, propertyName);
        }

        public void Set(string propertyName, string propertyValue)
        {
            if (!userSettingsStore.CollectionExists(collection))
                userSettingsStore.CreateCollection(collection);
            userSettingsStore.SetString(collection, propertyName, propertyValue);
        }
    }
}
