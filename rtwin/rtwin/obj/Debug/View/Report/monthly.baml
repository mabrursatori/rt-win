   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:rtwin.View.Reportrtwin.View.Report  5      g cMicrosoft.ReportViewer.WinForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91tSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinFormsMicrosoft.Reporting.WinForms 5
      S OMaterialDesignExtensions, Version=2.7.0.0, Culture=neutral, PublicKeyToken=nullwQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions!MaterialDesignExtensions.Controls 5   T       rtwin.View.Report.monthly   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:rtwin.View.Report     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      \rvSclr-namespace:Microsoft.Reporting.WinForms;assembly=Microsoft.ReportViewer.WinForms  5
      Iwpf9http://schemas.microsoft.com/netfx/2007/xaml/presentation     5      fcontrolsQclr-namespace:MaterialDesignExtensions.Controls;assembly=MaterialDesignExtensions     6T   .��5      �   � RowDefinitions  5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $��3��6   $
��Left=�6%   $	��Top=�6@   $	��950��6X   $	��523��6d      RectangleView#���   6q   �� 5   
   $��Laporan Bulanan��6     MaterialDesignGroupBox#���  6,   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6]   $��0q�6�   $	��900��6�   $	��523��6�   $��-85, 5, 0, 0q�6�   .��5      �� $��Stretch=�6   $��Stretch=�69   $
��Auto=�5      $
��Auto=�6<   .��5      � $	��Top=�6     5      �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5      $
��auto �6(   68   �� 5       $
��auto �6(   68   �� 5!      $
��auto �6(   68   �� 5"      $
��auto �6(   68   �� 5#      $
��auto �6(   68    � ColumnDefinitions 5%      �� 5&      $��11 �6+   68   �� 5'      $	��140 �6+   �� 5(      $	��220 �6+   69   �� 5)      $	��150 �6+   69   �� 5*      $	��220 �6+   69   .+�5,      	� $��0��6"   $��
4,14,15,14q�6/   $��1��6C   $��Center=�6S   $��13(�6n   $
��Bold"�6|     MaterialDesignRadioButton#��[ 5-      
 � Tag$
 True��5.      $��20��6    d� 	IsChecked 5/      �� 50       �� Path$	 Tag�6&    �� RelativeSource 61   �� *Self+ �� ValidationRules 51   "   52      .��53   1   	Bulanan55      �� 56      -   5         ��Name$ cmbBulan��56      $��0��61   $��2��6>   $��10q�6N   	 �� SelectedIndex$	 0��6Z   $��28��6l   �� 57      
 �� Orientation$
 
Horizontal=�6!   $��0��6:   $��3��6G   $��2��6W   .+�58      �� $��10,15q�6$      MaterialDesignBody2TextBlock#��[ 63   $��Center=�6i   �� 6�   $�Tahun��6�   6�   �� 59      -   5        $ cmbTahun��59   #   $��10q�65   $	��190��6A   5:      �� 5;      $��1��6    $��0��6-   $��10,16q�6=   #��[ 6L   $��Center=�6�   $��16��6�   $��2��6�   Jenis Laporan6�   �� 5<      -   5        $ cmbJenisLap��5<      $��1��64   $��2��6A   $��10q�6Q   $��28��6]   � 5=      $��2��6   $��5��6(   ���	#FFE2E4E4$��0 10 0 0q�6T   .+�5>      �� #��[ 6$   $��Center=�6[   $��10 0 0 0q�6v   Filter6�   5@      �� 5B      $��3��6    $��0��6-   $��10 20 10 10q�6>   #��[ 6T   $��2��6�   NIP6�   �� 5C      -   5         ��Name$ svNip��5C   1   $��3��6$   $��Stretch=�6@   $��Stretch=�6^   $��10q�6z   $
��Auto=�5D      $
��Auto=�6<   $��2��6_   .��5E      �� $��Center=�6%   $
��auto��6B   $
 Vertical=�6O   .+�5F      :  4MaterialDesignExtensions.Controls.TextBoxSuggestions     TextBoxSuggestionsSource 6:   �� $ TextBoxSuggestionsSource�   TextBox. 5G   "   �� -   5         ��Name$ txtNip��5G   Q   $	��290��6*   $
��Left=�66   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Masukan Nama Atau Nip��6a    % !MaterialDesignFloatingHintTextBox#��[ 6�   ��6�   �� $
 Text� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5H      5I      5J      �� 5O      $��4��6    $��0��6-   $��10 20 10 10q�6=   #��[ 6R   $��2��6�   Deputi6�   �� 5P      -   5        $ 	cmbDeputi��5P      $��4��6]   $��2��6j   $��
0,10,20,10q�6z   $��28��6�   �� 5R      $��5��6    $��0��6-   $��10 20 10 10q�6=   #��[ 6R   $��2��6�   Bagian/Bidang6�   �� 5S      -   5        $ 	cmbBagian��5S      $��5��6\   $��2��6i   $��
0,10,20,10q�6y   $��28��6�   �� 5U      $��6��6    $��0��6-   $��10 20 10 10q�6=   #��[ 6R   $��2��6�   	Jabatan6�   �� 5V      -   5        $ 
cmbJabatan��5V      $��6��63   $��2��6@   $��
0,10,20,10q�6P   $��28��6d   �� 5X      $��7��6    $��0��6-   $��10 20 10 10q�6=   #��[ 6R   $��2��6�   Grade6�   �� 5Y      -	   5        $ cmbGrade��5Y      $��7��61   $��2��6>   $��
0,10,20,10q�6N   $��28��6b   �� 5[      $��8��6    $��0��6-   $��10 20 10 10q�6=   #��[ 6R   $��2��6�   Status6�   �� 5\      -
   5        $ 	cmbStatus��5\      $��8��62   $��2��6?   $��
0,10,20,10q�6O   $��28��6c   �� 5_      -   5        $��11��5_      $
��Auto��6+    � ToolTip$3 -MaterialDesignRaisedButton with Round Corners��6T   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 10��6�   $��1,5,0,30q�6�     MaterialDesignRaisedButton#��[ 6�   $��	Tampilkan��6  $��1��6  �� 5d      $��4��6    $��3��6-   $��30 20 10 10q�6=   #��[ 6R   Status Biro6�   �� 5e      -   5        $ cmbBiro��5e      $��4��6X   $��4��6e   $��
0,10,20,10q�6u   $��28��6�   �� 5g      $��5��6    $��3��6-   $��30 20 10 10q�6=   #��[ 6R   
Sub Bagian6�   �� 5h      -   5        $ cmbSubbagian��5h      $��5��65   $��4��6B   $��
0,10,20,10q�6R   $��28��6f   �� 5j      $��6��6    $��3��6-   $��30 20 10 10q�6=   #��[ 6R   
Golongan6�   �� 5k      -   5        $ cmbGolongan��5k      $��6��64   $��4��6A   $��
0,10,20,10q�6Q   $��28��6e   �� 5m      $��7��6    $��3��6-   $��30 20 10 10q�6=   #��[ 6R   Eselon6�   �� 5n      -   5        $ 	cmbEselon��5n      $��7��62   $��4��6?   $��
0,10,20,10q�6O   $��28��6c   5p      5q      5r      5u      5v      