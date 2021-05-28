*Лабораторная работа 5 по предмету "Компьютерная графика". Вариант 12*

**Описание**: десктопное приложение позволяет пользователю применить на практике основные методы и алгоритмы отсечения отрезков и многоугольников. Программа написана на языке C#.

**Установка**: для запуска программы необходимо скачать содержимое репозитория, пройти по пути _lab5 - bin - Release_  и дважды кликнуть на "lab5.exe".

**Использование**: для работы алгоритма средней точки, предназначенного для отсечения отрезков отсекающим окном, необходимо ввести в текстовом поле данные в следующем формате

```
X1_1 Y1_1 X2_1 Y2_1
X1_2 Y1_2 X2_2 Y2_2
...
X1_n Y1_n X2_n Y2_n *координаты отрезков*
Xmin Ymin Xmax Ymax *координаты отсекающего прямоугольного окна*
  ```

<br /> ![point](/screenshots/middle.png)

Для корректного выполнения алгоритма отсечения отрезков выпуклым многоугольником предназначен следующий формат входных данных:

```
m *число сторон многоугольника*
  
X1_1 Y1_1 X2_1 Y2_1
X1_2 Y1_2 X2_2 Y2_2
...
X1_n Y1_n X2_n Y2_n *координаты отрезков*

X_1 Y_1
X_2 Y_2
...
X_m Y_m *координаты углов многоугольника*
```

<br /> ![poly](/screenshots/clip.png)

