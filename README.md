# AutoCcolor

Плагин <b>AutoCcolor</b> для SCP: SL автоматически изменяет цвет освещения в Зоне 02, добавляя яркие и динамичные эффекты в игру. Используйте его, чтобы оживить атмосферу, но будьте осторожны с настройками:
- Не задавайте значения цветов более 10, чтобы избежать чрезмерной яркости.
- Не устанавливайте интервал таймера менее 0.5 секунды, чтобы избежать дискомфорта для глаз.
- <b>Пример, как делать не надо:</b> accolor start 10-20 0-255 52-255 .2
- <b>Пример, как делать надо:</b> accolor start 0-10 0-10 0-10 .6

## **Команды**

- **`autoccolor(accolor) start [red(0-255)] [green(0-255)] [blue(0-255)] [time] `** - Запускает таймер, который будет менять цвет Зоны 02.
- **`autoccolor(accolor) stop`** - Удаляет таймер.

## **Разрешения**

- **`accolor.start`** - Разрешает запускать таймер.
- **`accolor.stop`** - Разрешает удалять таймер.
