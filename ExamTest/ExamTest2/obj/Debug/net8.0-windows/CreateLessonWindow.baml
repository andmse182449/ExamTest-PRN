   M S B A M L   `   `   `  ����D  @ExamTest2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:ExamTestExamTest  5   	   !    ExamTest.CreateLessonWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:ExamTest     5   	     � Title$  CreateLessonWindow��5   	   $	��450��6$   $	��800��61    � WindowStartupLocation$ CenterScreen=�6=   .��5	      � $��20,75,34,20q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   $��48��6*   �� 5      $
��Auto �6   $��45��6*   �� 5      $
��Auto �6   $��52.92��6*   �� 5      $
��Auto �6   $��30��6*   �� 5       � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��
Lesson ID:��6   $��0��6&   $��0��63   $��	0,0,10,10q�6C   $��15(�6V   �� 5   
   -   5         ��Name$ LessonIdTextBox��5      $��0��6+   $��1��68   $��0,0,0,10q�6H   $��15(�6Z   �� 5   
   $��Lesson Name:��6   $��1��6(   $��0��65   $��	0,0,10,10q�6E   $��15(�6X   �� 5   
   -   5        $ LessonNameTextBox��5      $��1��6-   $��1��6:   $��0,0,0,10q�6J   $��15(�6\   �� 5   
   $��Create Date:��6   $��2��6(   $��0��65   $��	0,0,10,10q�6E   $��15(�6X   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ CreateDatePicker��5      $��2��6/   $��1��6<   $��0,0,0,10q�6L   $��15(�6^   �� 5   
   -   5        $��Create Lesson��5      $��4��6)   $��1��66   $
��Left=�6F   $	��123��6a   $��30��6m   $��
493,10,0,0q�6�   $	��Top=�6�   $��15(�6�   $
��Bold"�6�   �� 5    
   $��1��6   $��ADD NEW EXERCISE��6    $
��Left=�6;   $��209,-56,0,0q�6V   $	��Top=�6k   $��16(�6�   $
��Bold"�6�   5!      5"      