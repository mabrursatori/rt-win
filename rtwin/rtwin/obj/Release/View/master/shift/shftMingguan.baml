   M S B A M L   `   `   `  ���� @  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:rtwin.View.master.shiftrtwin.View.master.shift  *    $rtwin.View.master.shift.shftMingguan   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:rtwin.View.master.shift     V RMaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  .���   � RowDefinitions  �� $
��auto ��� $
��auto ��� $
��auto �.+��� �� $��0�� �� Orientation$ 
Horizontal=�$
��Left=�.+�� $	��134��.+��� -    ��Name$ 
btnAddData��   MaterialDesignRaisedButton#��[  3  -MaterialDesignThemes.Wpf.ButtonProgressAssist   Value$ -1Q�   IsIndicatorVisible .    IsIndeterminate . $��Tambah Data��$	��2,0q��� $��0��$ 
Horizontal=�$��Right=�$��0,0,20,0q�.+��� $��	0,10,20,0q�$��Center=�$��Center=� " MaterialDesignCaptionTextBlock#��[ Urutkan Berdasar�� -    ��Name$ cmbSort��$��Center=�$��Center=� & "MaterialDesignFloatingHintComboBox#��[ �� -   $ btnSort��$��10,0,0,0q� 0 ,MaterialDesignFloatingActionMiniAccentButton#��[ $
��Left=�.��'  !MaterialDesignThemes.Wpf.PackIcon  -     Name$ 	arrowSort���  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.1.1345, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowUp=�$��24��$��24���� $��1��$ Vertical=�$��Stretch=�.+�&   System.Windows.Controls.DataGrid  -   	  Name$	 dgShiftMingguan��$��	0  8 10 0q�
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 *    CanUserAddRows .     
IsReadOnly .    Columns 4  .System.Windows.Controls.DataGridTemplateColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 Edit��   CellTemplate �� .R��� $
 edit��-   $��30��$��30�� / +MaterialDesignFloatingActionMiniLightButton#��[  � ToolTip$
 Edit��.��  $
 Edit=�$��24��$��24��  $ Hapus�� �� .R��� $ hapus��-   $��30��$��30��#��[ 
���  ��
���  ��$ Hapus��.��  $ Delete=�$��20��$��20���� .+��  � ColumnDefinitions �� $��* ��� $��* �.+��� $��1��$ 
Horizontal=�$��Right=�$��
0,10,30,10q�.+��� -   $ 	firstPage��$��0,0,15,0q� . *MaterialDesignFloatingActionMiniDarkButton#��[ $ Previus��.��  $ 	FirstPage=�$��24��$��24���� -	   $ prevPage��$��0,0,15,0q�#��[ $ Previus��.��  $ PagePrevious=�$��24��$��24���� $��Center=�$��Center=�$ 
Horizontal=�.+��� .��	Showing�� -
    ��Name$
 dari��$��Center=�$��Center=�#��[ 21�� .��To�� -   $ sampai��$��Center=�$��Center=�#��[ 21�� .��of�� -   $ total��$��Center=�$��Center=�#��[ 21�� .��	entries�� -   $ nextPage��$��15,0,0,0q�#��[ $
 Next��.��  $ PageNext=�$��24��$��24���� -   $ lastPage��$��15,0,0,0q�#��[ $ 	Last Page��.��  $ LastPage=�$��24��$��24���� $��0��$ 
Horizontal=�$
��Left=�$��
10,10,0,10q�.+��� $��Center=�$��Center=�#��[ Jumlah data�� -   $ 
cmbJumData��$��Center=�$��Center=�$��	10,0,0,10q�#��[ .@���  �� 
IsSelected . .��10�� .��20�� .��30