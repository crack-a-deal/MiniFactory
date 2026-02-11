# SCADA WATER SYSTEM

Учебный промышленный симулятор, моделирующий систему водоподготовки с управлением в реальном времени.
<img width="1606" height="896" alt="screen" src="https://github.com/user-attachments/assets/e6e617ba-c491-4392-a88b-b1a235f3cf60" />

## Основные системы
### Архитектура устройств
Каждое устройство работает независимо на собственной Finite State Machine (FSM).
Реализованные устройства:
- Насос
- Клапан
- Резервуар

> [!NOTE]
> Каждое устройство содержит:
> - Изолированные классы состояний
> - Явную логику переходов

### Сценарная система
Сценарии настраиваются через ScriptableObject.

<img width="463" height="632" alt="screen2" src="https://github.com/user-attachments/assets/fe41ef86-ace6-4f67-b1c9-9597b56fe25c" />
