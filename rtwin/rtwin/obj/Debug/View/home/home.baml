   M S B A M L   `   `   `  ����@  <rtwin, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:rtwin.View.homertwin.View.home  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5          rtwin.View.home.home   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:rtwin.View.home     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5      .��5      �   � RowDefinitions  5   
   �� 5      $	��140 �6   6+   �� 5      $��* �6   6)   .+�5   
   � $��0��6   .+�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   63   �� 5      $��* �6'   63   �� 5      $��* �6'   63   .+�5      �� -   5         ��Name$ 
spIjinHari��5   *   $��0��6   $��0��6>    �� Orientation$ 
Horizontal=�6N   .+�5      � -   5         �Name$ cardIjinHari��5      $��0 0 0 10q�61   .+�5      �� $	��120��6$   $	��300��61   $��Center=�6=   $��Center=�6Z      NotifPerHari#���   6u   5      � 5        5       �� 5!   "   $��40 �60   �� 5"   "   $
��Auto �60   �� 5#   "   $��70 �60   .+�5%      �� $��0��6)   $��Center=�66   $	��Top=�6S   $��22(�6k   $��0 5 0 0q�6y     	TextBlock#���  6�   Notifikasi Ijin Per Hari5'      �� 5(      $��1��6(   $	��300��65   
�������6A   �� 5)      -   5         ��Name$ ijinHari��5)   (   $��2��6:   $��	40 0 16 0q�6G   $��Bottom=�6Z   $
��Left=�6u   $��54(�6�   #���  6�   125+      �� 5,      $��2��6)   $ 
Horizontal=�66   $��	16 0 16 8q�6O   $��Right=�6b   .+�5-   "   ��   ButtonCircleHome#���  6)    � ToolTip$ Detail��6U   $��Right=�6f   $��Bottom=�6�   $��2 0 15 0q�6�   .��5.   &   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Details=�6>   $��24��6M   $��24��6Y   5/   #   51      52      53      54      �� 55      -   5        $ 	spIjinJam��55   *   $��0��6   $��1��6=   $ 
Horizontal=�6M   .+�56      � -   5        $ cardIjinJam��56      $��0 0 0 10q�60   .+�57      �� $	��120��6$   $	��300��61   $��Center=�6=   $	��Top=�6Z     NotifPerJam#���  6r   $��0,5,0,0q�6�   � 58        59      �� 5:   "   $��40 �60   �� 5;   "   $
��Auto �60   �� 5<   "   $��70 �60   .+�5>      �� $��0��6)   $��Center=�66   $	��Top=�6S   $��22(�6k   $��0 5 0 0q�6y   #���  6�   Notifikasi Ijin Per Jam5@      �� 5A      $��1��6(   $	��300��65     	Separator#���  6A   �� 5B      -   5        $ 
ijinPerjam��5B   (   $��2��6<   $��	40 0 16 0q�6I   $��Bottom=�6\   $
��Left=�6w   $��54(�6�   #���  6�   125D      �� 5E      $��2��6)   $ 
Horizontal=�66   $��	16 0 16 8q�6O   $��Right=�6b   .+�5F   "   �� #���  6)   $ Detail��6U   $��Right=�6f   $��Bottom=�6�   $��2 0 15 0q�6�   .��5G   &     $ Details=�6>   $��24��6M   $��24��6Y   5I   #   5K      5L      5M      5N      �� 5O      $��0��6   $��2��6*   $ 
Horizontal=�6:   .+�5P      � -   5        $ 
cardLembur��5P      $��0 0 0 10q�6/   .+�5Q      �� $	��120��6$   $	��300��61   $��Center=�6=   $��Center=�6Z     NotifLembur#���  6u   � 5R        5S      �� 5T   "   $��40 �60   �� 5U   "   $
��Auto �60   �� 5V   "   $��70 �60   .+�5X      �� $��0��6)   $��Center=�66   $	��Top=�6S   $��22(�6k   $��0 5 0 0q�6y   #���  6�   Notifikasi Lembur5Z      �� 5[      $��1��6(   $	��300��65   �� 5\      -   5        $ lembur��5\   (   $��2��68   $��	40 0 16 0q�6E   $��Bottom=�6X   $
��Left=�6s   $��54(�6�   #���  6�   125^      �� 5_      $��2��6)   $ 
Horizontal=�66   $��	16 0 16 8q�6O   $��Right=�6b   .+�5`   "   �� #���  6)   $ Detail��6T   $��Right=�6e   $��Bottom=�6�   $��2 0 15 0q�6�   .��5a   &     $ Details=�6>   $��24��6M   $��24��6Y   5b   #   5d      5e      5f      5g      5h      5i      �� 5k   
   $��1��6   .+�5l      � .+�5m      �� $	��350��6   $
��1000��6)   $��11 0 0 0q�66   $
��Left=�6H    �� RadiusX$ 20��6c   	 �� RadiusY$	 20��6p   
�������
 J� Effect
 5n      3  -System.Windows.Media.Effects.DropShadowEffect  5o         
BlurRadius$ 20Q�6+      RenderingBias$ Quality=�6;   5q      �� 5r      $��Grafik Kehadiran��6   $
��Left=�64   $	��Top=�6O   $��22(�6g   $��20 5 0 0q�6u     LiveCharts.Wpf.PieChart  5s      -	   5          Name$	 pie��5s   ,   $	��300��6   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Bottom=�69      	Hoverable .     DataTooltip 6�   Z� 
 5t        5u      $ 20Q�6+      Series 5x        LiveCharts.Wpf.PieSeries  -
   5          Name$ hadir��5x   6     LiveCharts.Wpf.Series   Title$ Hadir��6(      Values;  5LiveCharts.Wpf.Converters.NumericChartValuesConverter$ 3 6E      
DataLabels .    
LabelPoint 5y       �� *
PointLabel+  5z      -   5        $	 bak��5z   4   $	 BAK��6(   $ 4 6A    .  5{       �� *
PointLabel+  5|      -   5        $	 cbs��5|   4   $	 CBS��6(   $ 6 6A    .  5}       �� *
PointLabel+  5~      -   5        $ cp��5~   3   $ CP��6(   $ 2 6?    .  5       �� *
PointLabel+  5�      -   5        $ ct��5�   3   $ CT��6(   $ 2 6?    .  5�       �� *
PointLabel+  5�      -   5        $ dl��5�   3   $ DL��6(   $ 2 6?    .  5�       �� *
PointLabel+  5�      -   5        $ pd��5�   3   $ PD��6(   $ 2 6?    .  5�       �� *
PointLabel+  5�      -   5        $ sakit��5�   2   $ S��6(   $ 2 6A    .  5�       �� *
PointLabel+  5�      -   5        $	 sdr��5�   4   $	 SDR��6(   $ 2 6A    .  5�       �� *
PointLabel+  5�      -   5        $ cptplg��5�   7   $ CPTPLG��6(   $ 2 6G    .  5�       �� *
PointLabel+  5�      -   5        $ telat��5�   6   $ Telat��6(   $ 2 6E    .  5�       �� *
PointLabel+5�      5�      5�      5�      5�      