   M S B A M L   `   `   `  ����  	Simulator    Simulator.Login   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   
�������  � Title$  Connect��5   	   $	��180��6   $	��380��6&    � 
ResizeMode$ NoResize=�62    � WindowStartupLocation$ CenterScreen=�6H   .��5      � $��5q�6   $��Center=�6   $��Center=�63    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   $	��100��6,   �� 5      $
��Auto �6   $	��250��6,    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��0��6   $	��IP:��6-   $��0,5,0,5q�6;   �� 5   
   -   5         ��Name$ 	IPTextbox��5      $��0��6%   $��1��62   $	��250��6B   $��0,5,0,5q�6N   $��	127.0.0.1��6_   �� 5   
   $��1��6   $��0��6   $��Port:��6-   $��0,5,0,5q�6=   �� 5   
   -   5        $ PortTextbox��5      $��10000��6'    �� 
IsReadOnly . $��1��6F   $��1��6S   $	��250��6c   $��0,5,0,5q�6o   �� 5   
   -   5         ��Name$ ErrorTextLabel��5      $��3��6(   $��0��65   $��2��6E   
���  ��$��Right=�6j   ��6�   �� *StatusMessage+�� 5   
   -   5         ��Name$ ConnectButton��5      $��2��6(   $��1��65   $��Connect��6E   $��0,5,0,5q�6W   6h   5      5      