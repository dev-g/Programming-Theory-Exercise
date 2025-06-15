
# Programming Theory Exercise

The project used for the Unity Junior Programmer, Apply Object-Oriented Principles exercise on programming theory.

The exercise is available here: https://learn.unity.com/pathway/junior-programmer/unit/apply-object-oriented-principles/tutorial/submission-programming-theory-in-action?version=6.0

This version of the code uses `6000.0.47f1`.

The implementation of LightBulb state is spread across three classes, as shown in the diagram below.

There is a "Light Bulb" prefab for the UI.  The "Light Bulb" UI has a "Type" property allowing a selection of 
* BASIC
* DIMMABLE
* COLOR_CHANGING

There is a single LightBulbController script supporting all three types of bulbs.

```mermaid
---
title: LightBulb Classes
config:
  class:
    hideEmptyMembersBox: true
---
classDiagram

LightBulb <|-- DimmableLightBulb
DimmableLightBulb <|-- ColorChangingLightBulb

class LightBulb {
  - _isOn: bool = false
  + IsOn() bool
  + SetPower(on: bool)
  + ToggleOnOff()
  + DescribeState() string
}


class DimmableLightBulb {
  - _powerPercent: int
  + PowerPercent() int
  + SetPower(powerPercent: int)
  + DescribeState() string
}


class ColorChangingLightBulb {
  + Color: LightColor
  + SetPower(powerPercent: int, color: LightColor)
  + DescribeState() string
}

class LightColor {
  <<enumeration>>
  RED
  BLUE
  GREEN
  WHITE
}

ColorChangingLightBulb o--> LightColor : color

```