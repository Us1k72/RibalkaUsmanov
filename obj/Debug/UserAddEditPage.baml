   M S B A M L   `   `   `  ����C  ?FunStore, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:FunStoreFunStore  5          FunStore.UserAddEditPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:FunStore     5        N� Title$  UserAddEditPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��211* �6   �� 5      $
��589* �6    � RowDefinitions 5   
   �� 5      $	��86* �6   �� 5      $
��119* �6   �� 5      $	��85* �6   �� 5      $	��92* �6   �� 5      $	��68* �6   .+�5   
   �� $��0��6   $��0��6    $��Имя��6-   $��30(�6;   $��Center=�6I   $��Center=�6f   6�   �� 5   
   -   5        $��nazvanie��5   E   $��1��6(   $��0��68   $
��Left=�6U   $��Center=�6p   $	��400��6�   $��30��6�   ��6   �� *Name+6�   �� 5   
   $��0��6   $��1��6!   $��Роль��6.   $��25(�6=   $��Center=�6K   $��Center=�6h   6�   �� 5   
   -   5        $��MaterialCombo��5   �   $��1��6   $��1��6    $
��Left=�60   $��Center=�6K   $	��400��6f   $��30��6r    �� DisplayMemberPath$
 Name��6�    �� SelectedItem 6~   �� *Role+6�   �� 5   
   $��0��6   $��2��6    $��Логин ��6-   $��30(�6>   $��Center=�6L   $��Center=�6i   6�   �� 5   
   -   5        $
��Cena��5   G   $��1��6   $��2��6"   $
��Left=�6S   $��Center=�6n   $	��400��6�   $��30��6�   ��6/   �� *Login+6�   �� 5   
   $��0��6   $��3��6    $��Пароль��6-   $��30(�6>   $��Center=�6L   $��Center=�6i   6�   �� 5   
   -   5        $��kolvo��5   0   $��1��6   $��3��6"   $
��Left=�6W   $��Center=�6r   $	��400��6�   $��30��6�   ��6=   �� *
Password+6�   �� 5   
   -   5        $��btnSave��5   x   $��1��6   $��4��6!   $
��Left=�6.   $��Center=�6I   $��Сохранить��6d   6�   �� 5    
   -   5         ��Name$ btnSave_Copy��5    u   $��1��6   $��4��6!   $
��Left=�6.   $��Center=�6I   $��Отмена��6d   $��	110,0,0,0q�6�   5!      5"      