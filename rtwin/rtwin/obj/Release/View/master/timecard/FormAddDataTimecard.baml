   M S B A M L   `   `   `  ���� @  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:rtwin.View.master.timecardrtwin.View.master.timecard  H DWPF.Bootstrap, Version=0.0.5.0, Culture=neutral, PublicKeyToken=nullV;clr-namespace:WPF.Bootstrap.Controls;assembly=WPF.BootstrapWPF.Bootstrap.Controls  WPFToolkit.ExtendeddEclr-namespace:Xceed.Wpf.Toolkit.Obselete;assembly=WPFToolkit.ExtendedXceed.Wpf.Toolkit.Obselete 4    .rtwin.View.master.timecard.FormAddDataTimecard   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     :local(clr-namespace:rtwin.View.master.timecard     Q	bootstrap;clr-namespace:WPF.Bootstrap.Controls;assembly=WPF.Bootstrap     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  X TXceed.Wpf.Toolkit, Version=3.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  OosbEclr-namespace:Xceed.Wpf.Toolkit.Obselete;assembly=WPFToolkit.Extended  .��� .+�)  #MaterialDesignThemes.Wpf.DialogHost  -      Name$  dialogAlert��$��0,0,20,0q�$	��Top=�   DialogContent  � -     �Name$ contentAlert��  � NavigationUIVisibility$ Hidden=�$��400px��.���� -    ��Name$ gbTitel��$��Tambah Data Waktu Kerja��   MaterialDesignGroupBox#���   $��16q�+  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�$��0q�.���  � RowDefinitions �� $	��320 ��� $��50 �.+��� -    ��Name$ containerForm��$��0�� �� Orientation$ Vertical=�$	��Top=�.+��� -   	 ��Name$	 	exception��� 
 � ColumnDefinitions
 �� $	��100 ��� $	��200 �.+��� $��0��$ 
Horizontal=�$
��Left=�$��Center=�.+���    MaterialDesignBody2TextBlock#��[ $	��100��$��0��$��Center=�
Kode Range�� $��1��.+��� -    ��Name$ 	kodeRange��$��1�� % !MaterialDesignFloatingHintTextBox#��[ � 
 �� $	��100 ��� $	��200 �.+��� $��0��$ 
Horizontal=�$
��Left=�$��Center=�.+��� #��[ $	��100��$��0��$��Center=�	Jam Masuk�� $��1��.+�%  Xceed.Wpf.Toolkit.MaskedTextBox  -     Name$ jamMasuk��   Mask$ 00:00��#��[ .��� 
 �� $	��100 ��� $	��200 �.+��� $��0��$ 
Horizontal=�$
��Left=�$��Center=�.+��� #��[ $	��100��$��0��$��Center=�
Jam Pulang�� $��1��.+�  -   $ 	jamPulang��$ 00:00��#��[ � 
 �� $	��100 ��� $	��200 �.+��� $��0��$ 
Horizontal=�$
��Left=�$��Center=�.+��� #��[ $	��100��$��0��$��Center=�Toleransi Telat�� $��1��.+�  -	   $ tolTelat��$ 00��#��[ .��� 
 �� $	��100 ��� $	��200 �.+��� $��0��$ 
Horizontal=�$
��Left=�$��Center=�.+��� #��[ $	��100��$��0��$��Center=�Toleransi Pulang�� $��1��.+�  -
   $ 	tolPulang��$ 00��#��[ .��� 
 �� $	��100 ��� $	��200 �.+��� $��0��$ 
Horizontal=�$
��Left=�$��Center=�.+��� #��[ $	��100��$��0��$��Center=�
Limit Awal�� $��1��.+�  -   $ 	limitAwal��$ 00:00��#��[ � 
 �� $	��100 ��� $	��200 �.+��� $��0��$ 
Horizontal=�$
��Left=�$��Center=�.+��� #��[ $	��100��$��0��$��Center=�Limit Akhir�� $��1��.+�  -   $ 
limitAkhir��$ 00:00��#��[ � 
 �� $	��100 ��� $	��200 �.+��� $��0��$ 
Horizontal=�$
��Left=�$��Center=�.+��� #��[ $	��100��$��0��$��Center=�	Jam Kerja�� $��1��.+�  -   $ jamKerja��$ 00:00��#��[ .��� 
 �� $	��100 ��� $	��200 �.+��� $��0��$ 
Horizontal=�$
��Left=�$��Center=�.+��� #��[ $	��100��$��0��$��Center=�Jam Istirahat�� $��1��.+�  -   $ jamIstirahat��$ 00:00��#��[ .���� $��1��$ 
Horizontal=�.+��� -    ��Name$ btnsave��  MaterialDesignRaisedButton#��[ $��70�� � ToolTip$/ )Resource name: MaterialDesignRaisedButton��.��Save�� -   $ btnClose��$��10q�#��[ 
���  ��
���  ��$��70��$/ )Resource name: MaterialDesignRaisedButton��.��Close�� -   $ 
lodongSave��$��0,10,0,0q�$ 
Horizontal=�$y�Hidden=�.+�#  MaterialDesignThemes.Wpf.Card     UniformCornerRadius$ 14Q�$��4q�.���  % !MaterialDesignCircularProgressBar#��[  � Value$ 50Q� � IsIndeterminate . 