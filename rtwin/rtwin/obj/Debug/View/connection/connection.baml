   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:rtwin.View.connectionrtwin.View.connection  5      &     rtwin.View.connection.connection   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:rtwin.View.connection     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5
      � .+�5   
   ��   �� Orientation$  Vertical=�6   $��Center=�6,   .+�5      �� $��	20,0,20,0q�6   .+�5      �� -   5         ��Name$ 
cmbKoneksi��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Jenis Koneksi��6/    �� 
IsEditable .  &  "MaterialDesignFloatingHintComboBox#��[  6p   .@�5      �� -   5        $��ss��5   J    �� 
IsSelected . $��
Sql Server��65   5      �� 5      -   5        $��pg��5   6   $��Postgres��6#   5      5      5      �� 5      $��20q�6   .+�5      �� -   5         ��Name$ 
serverName��5       * &MaterialDesignOutlinedTextFieldTextBox#��[ 6.   $	��Top=�6n    �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6�   " �� VerticalScrollBarVisibility$
 Auto=�6�   $ 
ServerName��6�   {�6�   �� 	 �� Path$	 	IsChecked�
 �� ElementName$;
 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox��5      �� 5      $��20q�6   .+�5      �� -   5        $ UsernameServer��5      #��[ 62   $	��Top=�6r    . $
 Wrap=�6�   $
 Auto=�6�   $ Username��6�   {�6   �� $	 	IsChecked�$;
 5MaterialDesignOutlinedTextFieldTextBoxEnabledComboBox��5      �� 5      $��20q�6   .+�5!      G� -   5         G�Name$ passwordServer��5!       2 .MaterialDesignOutlinedPasswordFieldPasswordBox#��[ 66   $	��Top=�6~   $ Password��6  {�6�   �� $	 	IsChecked�$C
 =MaterialDesignOutlinedPasswordFieldPasswordBoxEnabledComboBox��6  5"      �� 5#      $��20,0,0,0q�6   $  
Horizontal=�6+   $
��Left=�6D   .+�5$      �� -   5         ��Name$ 
btnConnect��5$       # MaterialDesignRaisedLightButton#��[ 6F   $	��100��6�    � ToolTip$4 .Resource name: MaterialDesignRaisedLightButton��6�   .��6�   	Connect5&      �� 5'      -   5        $��10q�5'      #��[ 6%   $2��,materialDesign:DialogHost.CloseDialogCommand��6^   $	��100��6�   .��6�   Cancel5)      5*      5+      5,      5-      