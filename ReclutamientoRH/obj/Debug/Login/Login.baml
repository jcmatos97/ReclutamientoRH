   M S B A M L   `   `   `  ����J  FReclutamientoRH, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ReclutamientoRH.LoginReclutamientoRH.Login  5   	   !    ReclutamientoRH.Login.Login   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35n jSAPBusinessObjects.WPF.ViewerShared, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ReclutamientoRH.Login     5   	     � Title$  ReclutamientoRH - Login��5   	   $	��350��6)   $	��250��66    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	    � Icon$ 
/Icono.ico��5   	   .��5      �  � RowDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��80 �6   �� 5      $	��100 �6   .+�5   
   �� -   5        $	��100��5      $��2��6   $��Iniciar Sesión��6*   $��Center=�6C   $��Center=�6`   $��0,0,0,50q�6{   6�   �� 5   
   -   5        $	��100��5      $��2��6   $��Registrarse��6*   $��Center=�6@   $��Center=�6]   $��0,50,0,0q�6x   6�   �� 5   
   $��0��6   $��Impact)�6   $��70(�61   $��R��6?   $��Center=�6K   $��0,0,35,0q�6h   $��Center=�6z   �� 5   
   $��0��6   $��Impact)�6   $��70(�61   $��H��6?   $��Center=�6K   $��35,0,0,0q�6h   $��Center=�6z   �� 5   
   $��0��6   $��SemiBold"�6   $��Arial)�64   $��10(�6G   $��Reclutamiento��6U   $��Center=�6m   $��0,0,0,65q�6�   $��Center=�6�   �� 5   
   -   5        $
��user��5       �� MaxLines$ 1��6   $��Center=�6+   $��	45,0,0,25q�6H   $��1��6[   $�� ��6h    �� TextWrapping$
 Wrap=�6p   $��Center=�6�   $	��120��6�   6�   G� 5   
   -   5        $
��pass��5      $��Center=�6#   $��	45,25,0,0q�6@   $��1��6S   $��Center=�6`   $	��120��6{   �� 5   
   $��Usuario:��6   $��Right=�6#   $��
0,0,155,25q�6?   $��1��6S   $��Center=�6`   �� 5   
   $��Clave:��6   $��Right=�6!   $��
0,25,155,0q�6=   $��1��6Q   $��Center=�6^   �� 5   
   $&�� ¿Busca una Vacante? Regístrate��6   $��Center=�69   $��0,0,0,0q�6V   $��2��6g   $��Center=�6t   �� 5   
   $��Inicio de Sesión��6   $��Center=�6+   $��0,0,0,0q�6H   $��Bottom=�6Y   5      5       