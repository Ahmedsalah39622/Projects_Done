
Namespace My

    'This class allows you to handle specific events on the settings class:
    ' The SettingChanging event is raised before a setting's value is changed.
    ' The PropertyChanged event is raised after a setting's value is changed.
    ' The SettingsLoaded event is raised after the setting values are loaded.
    ' The SettingsSaving event is raised before the setting values are saved.
    Partial Friend NotInheritable Class MySettings
        Private _ME_OLCConnectionString As String
        Public WriteOnly Property RunTimeConnectionString As String
            Set(ByVal value As String)
                My.Settings("osama\omar_DB_KAISSY_New_Connection250") = value
            End Set
        End Property
    End Class
End Namespace
