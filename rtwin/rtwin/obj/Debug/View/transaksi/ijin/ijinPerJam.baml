   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:rtwin.View.transaksi.ijinrtwin.View.transaksi.ijin  5      1clr-namespace:rtwin.ViewModelrtwin.ViewModel  5
      S OMaterialDesignExtensions, Version=2.7.0.0, Culture=neutral, PublicKeyToken=nullwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls 5      {Sclr-namespace:MaterialDesignExtensions.Converters;assembly=MaterialDesignExtensions#MaterialDesignExtensions.Converters 5      *    $rtwin.View.transaksi.ijin.ijinPerJam   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      9local'clr-namespace:rtwin.View.transaksi.ijin     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      -	viewModelclr-namespace:rtwin.ViewModel  5
      `controlsQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions  5      d
convertersSclr-namespace:MaterialDesignExtensions.Converters;assembly=MaterialDesignExtensions  5        � 	Resources  5      C  =MaterialDesignExtensions.Converters.NullToVisibilityConverter   notNullToVisibleConverter   	NullValue   NotNullValue��%@   &	          5   
   $ 	Collapsed=�6Q   $ Visible=�6g   5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��3��6   $
��Left=�6%   $	��Top=�6@   $
��1050��6X   $	��523��6e     RectangleView#��[ 6r   �� 5   
   $��0��6    �� Orientation$ 
Horizontal=�6"   $
��Left=�6;   .+�5      �� -   5         ��Name$ 
btnAddData��5      $��40��6B    � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��6O   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $��12 5 0 0q�6�     GreenButton#��[ 6�   .��5      �� $��Tambah Data��6   5       �� 5!      -   5        $ 	btnSearch��5!   '   $��10,5,0,0q�6     ButtonPagination#���  6R   $
��Left=�6}   .��5"      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Search=�6*   $��24��68   $��24��6D   5#      5%      �� 5&   
   $��0��6   $��Center=�6"   $��Center=�6?   .+�5'      )  #MaterialDesignThemes.Wpf.DialogHost  -   5        	  Name$	 dialog��5'   (   $	��Top=�5(      
   DialogContent
 5)      � 5*       5+      �� 5,      $��* �6,   69   �� 5-      $��70 �6,   6:   .+�5/      �� $��0��6%   $	��300��62   $ Vertical=�6>   $��0,0,0,0q�6U   $��Center=�6g   $
��Left=�6�   .+�50      (  "System.Windows.Controls.DatePicker  -   5          Name$ 	dpTglAwal��50   )   $	��250��6<   $��
10,10,10,0q�6H   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Tgl.Awal��6\   6�     51      -   5        $ 
dpTglAkhir��51   )   $	��250��6=   $��
10,10,10,0q�6I   $ 	Tgl.Akhir��6]   6�   �� 52      -   5         ��Name$ svNip��52   +   $��Stretch=�6:   $��Stretch=�6X   $��0,5,0,0q�6t   $
��Auto=�53      $
��Auto=�6<   .��54   "   �� $��Center=�6-   $	��250��6J   $ Vertical=�6V   $��0,16,0,0q�6m   .+�55   &   :  4MaterialDesignExtensions.Controls.TextBoxSuggestions     TextBoxSuggestionsSource 6B   ��  �� Path$ TextBoxSuggestionsSource�   TextBox. 56   *   �� -   5         ��Name$ txtNip��56   >   $	��250��62   $ Masukan Nama Atau Nip��6N    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6�   �� $
 Text� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�57   '   59   #   5:      �� 5;      -   5         ��Name$ lblNip��5;   (   $��Center=�68   $y�Hidden=�6U      MaterialDesignBody2TextBlock#��[ 6i   $
��auto��6�   6�   �� 5=      -	   5         ��Name$ cmbKodeDeputi��5=   �   $��	10,0,10,0q�6'   $ Deputi��6m   $	��250��6�    & "MaterialDesignFloatingHintComboBox#��[ 6�   5?      �� 5@      -
   5        $ cmbKodeBiro��5@   m   $��	10,0,10,0q�6'   $
 Biro��6;   $	��250��6a   #��[ 6�   5B      �� 5C      -   5        $ cmbStatusIjin��5C   u   $��
10,10,10,0q�6'   $ Status Ijin��6<   $	��250��6i   #��[ 6�   .@�5D   "   �� $��-��6/   6=   �� 5E   "   $��Diajukan��6/   6D   �� 5F   "   $��	Disetujui��6/   6E   5G      �� 5I         MaterialDesignLightSeparator#��[ 6(   5J      �� 5K      $��1��6%   $ 
Horizontal=�62   $��Right=�6K   $��20q�6g   .+�5L      �� -   5        $ btnTampilkan��5L   %    $  MaterialDesignRaisedAccentButton#��[ 6V   $	��100��6�   $5 /Resource name: MaterialDesignRaisedAccentButton��5M      .��6?   	Tampilkan5N      5O      5Q      5S      5T      �� 5U   
   $��0��6   $ 
Horizontal=�6"   $��Right=�6;   $��0,0,20,0q�6W   .+�5W      �� $��	0,10,20,0q�6   $��Center=�6+   $��Center=�6H    "	 MaterialDesignCaptionTextBlock#��[	 6c   Urutkan Berdasar5X      �� 5Y      -   5        $ cmbSort��5Y      $��Center=�6T   $��Center=�6q   #��[ 6�   5\      �� 5]      -   5        $ btnSort��5]   '   $��10,5,0,0q�6   #���  6O   $
��Left=�6z   .��5^        -   5          Name$ 	arrowSort��5^   *   $ ArrowUp=�6=   $��24��6L   $��24��6X   5_      5`      �� 5a   
   $��1��6   $ Vertical=�6"   $��Stretch=�6:   .+�5c      &	   System.Windows.Controls.DataGrid	  -   5         	 Name$ 	dgIjinJam��5c      $��	10 8 10 0q�6*    	  ColumnWidth5
  /System.Windows.Controls.DataGridLengthConverter$ *
 6=    	  CanUserAddRows .   	  
IsReadOnly .  	  Columns 5e      4  .System.Windows.Controls.DataGridCheckBoxColumn  5f      ,  &System.Windows.Controls.DataGridColumn   Header$ Status Ijin��6-   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *STATUS_IJIN+4  .System.Windows.Controls.DataGridTemplateColumn  5g      $
 Edit��6-      CellTemplate 5h      �� 5i      .R�5j   "   �� $
 edit��6)   -   5        $
��Left=�5j   J   $��30��6e   $��30��6q    
 
ButtonEdit#��� 
 6|   $
 Edit��6�   .��5k   &     $
 Edit=�6>   $��24��6J   $��24��6V   
�������6a   5l   #   5n      5q        5r      $ Hapus��6-    5s      �� 5t      .R�5u   "   �� $ hapus��6)   -   5        $
��Left=�5u   8   $��30��6g   $��30��6r     ButtonDelete#���  6~   
���  ��
���  ��$ Hapus��6�   .��5v   &     $ Delete=�6>   $��20��6L   $��20��6X   
�������6c   5w   #   5y      5|      5�      �� 5�      .+�5�      �  � ColumnDefinitions 5�      �� 5�      $��* �6+   67   �� 5�      $��* �6+   67   .+�5�      �� $��1��6!   $ 
Horizontal=�62   $��Right=�6K   $��	0,0,30,10q�6g   .+�5�      �� -   5        $ 	firstPage��5�   !   $��0,0,15,0q�6L   #���  6^   $ Previus��6�   .��5�        $ 	FirstPage=�66   $��24��6G   $��24��6S   5�      �� 5�      -   5        $ prevPage��5�   "   $��0,0,15,0q�6K   #���  6]   $ Previus��6�   .��5�        $ PagePrevious=�66   $��24��6J   $��24��6V   5�      �� 5�      $��Center=�6%   $��Center=�6B   $ 
Horizontal=�6]   .+�5�      �� .��6$   	Showing6-   �� 5�      -   5        $
 dari��5�   (   $��Center=�66   $��Center=�6S   #��[	 6o   215�      �� 5�      .��6$   To6(   �� 5�      -   5        $ sampai��5�   (   $��Center=�68   $��Center=�6U   #��[	 6q   215�      �� 5�      .��6$   of6(   �� 5�      -   5        $ total��5�   (   $��Center=�67   $��Center=�6T   #��[	 6p   215�      �� 5�      .��6$   	entries6-   5�      �� 5�      -   5        $ nextPage��5�   !   $��15,0,0,0q�6J   #���  6\   $
 Next��6�   .��5�        $ PageNext=�66   $��24��6F   $��24��6R   5�      �� 5�      -   5        $ lastPage��5�   !   $��15,0,0,0q�6J   #���  6\   $ 	Last Page��6�   .��5�        $ LastPage=�66   $��24��6F   $��24��6R   5�      5�      �� 5�      $��0��6!   $ 
Horizontal=�61   $
��Left=�6L   $��	10,0,0,10q�6g   .+�5�      �� $��Center=�6$   $��Center=�6A   #��[	 6\   Jumlah data5�      �� 5�      -   5        $ 
cmbJumData��5�   #   $��Center=�68   $��Center=�6U   $��	10,0,0,10q�6p   #��[ 6�   .@�5�      ��   �� 
IsSelected  . .��6=   106A   �� 5�      .��6+   206/   �� 5�      .��6+   306/   5�      5�      5�      5�      5�      5�      5�      