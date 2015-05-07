﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace System.Windows.Input
{
    public delegate void KeyEventHandler(object sender, KeyEventArgs e);
    public delegate void KeyboardFocusChangedEventHandler(object sender, KeyboardFocusChangedEventArgs e);

    public abstract class KeyboardEventArgs : InputEventArgs
    {
        public KeyboardDevice KeyboardDevice { get; private set; }

        public KeyboardEventArgs(RoutedEvent routedEvent, object originalSource, KeyboardDevice keyboardDevice, int timestamp) :
            base(routedEvent, originalSource, keyboardDevice, timestamp)
        {
            this.KeyboardDevice = keyboardDevice;
        }
    }

    public class KeyEventArgs : KeyboardEventArgs
    {
        public Key Key { get; private set; }
        public KeyStates KeyStates { get; private set; }

        public bool IsUp { get { return KeyStates == KeyStates.None; } }
        public bool IsDown { get { return KeyStates == KeyStates.Down; } }
        public bool IsRepeat { get; private set; }

        public KeyEventArgs(RoutedEvent routedEvent, object originalSource, KeyboardDevice keyboardDevice, int timestamp, Key key, KeyStates keyStates, bool isRepeat) :
            base(routedEvent, originalSource, keyboardDevice, timestamp)
        {
            this.Key = key;
            this.KeyStates = keyStates;
            this.IsRepeat = isRepeat;
        }

        public override void InvokeEventHandler(Delegate handler, object target)
        {
            if (handler is KeyEventHandler)
            {
                ((KeyEventHandler)handler)(target, this);
            }
            else
            {
                base.InvokeEventHandler(handler, target);
            }
        }
    }

    public class KeyboardFocusChangedEventArgs : KeyboardEventArgs
    {
        public IInputElement OldFocus { get; private set; }
        public IInputElement NewFocus { get; private set; }

        public KeyboardFocusChangedEventArgs(RoutedEvent routedEvent, object originalSource, KeyboardDevice keyboardDevice, int timestamp, IInputElement oldFocus, IInputElement newFocus) :
            base(routedEvent, originalSource, keyboardDevice, timestamp)
        {
            this.OldFocus = oldFocus;
            this.NewFocus = newFocus;
        }

        public override void InvokeEventHandler(Delegate handler, object target)
        {
            if (handler is KeyboardFocusChangedEventHandler)
            {
                ((KeyboardFocusChangedEventHandler)handler)(target, this);
            }
            else
            {
                base.InvokeEventHandler(handler, target);
            }
        }
    }

    public static class KeyEventHandlerExtensions
    {
        public static void Raise(this KeyEventHandler handler, object sender, KeyEventArgs e)
        {
            if (handler != null)
            {
                handler(sender, e);
            }
        }
    }

    public enum KeyStates
    {
        None,
        Down
    }

    public enum Key
    {
        None = 0,
        Cancel = 1,
        Back = 2,
        Tab = 3,
        LineFeed = 4,
        Clear = 5,
        Return = 6,
        Enter = 6,
        Pause = 7,
        CapsLock = 8,
        Capital = 8,
        HangulMode = 9,
        KanaMode = 9,
        JunjaMode = 10,
        FinalMode = 11,
        KanjiMode = 12,
        HanjaMode = 12,
        Escape = 13,
        ImeConvert = 14,
        ImeNonConvert = 15,
        ImeAccept = 16,
        ImeModeChange = 17,
        Space = 18,
        PageUp = 19,
        Prior = 19,
        PageDown = 20,
        Next = 20,
        End = 21,
        Home = 22,
        Left = 23,
        Up = 24,
        Right = 25,
        Down = 26,
        Select = 27,
        Print = 28,
        Execute = 29,
        Snapshot = 30,
        PrintScreen = 30,
        Insert = 31,
        Delete = 32,
        Help = 33,
        D0 = 34,
        D1 = 35,
        D2 = 36,
        D3 = 37,
        D4 = 38,
        D5 = 39,
        D6 = 40,
        D7 = 41,
        D8 = 42,
        D9 = 43,
        A = 44,
        B = 45,
        C = 46,
        D = 47,
        E = 48,
        F = 49,
        G = 50,
        H = 51,
        I = 52,
        J = 53,
        K = 54,
        L = 55,
        M = 56,
        N = 57,
        O = 58,
        P = 59,
        Q = 60,
        R = 61,
        S = 62,
        T = 63,
        U = 64,
        V = 65,
        W = 66,
        X = 67,
        Y = 68,
        Z = 69,
        LWin = 70,
        RWin = 71,
        Apps = 72,
        Sleep = 73,
        NumPad0 = 74,
        NumPad1 = 75,
        NumPad2 = 76,
        NumPad3 = 77,
        NumPad4 = 78,
        NumPad5 = 79,
        NumPad6 = 80,
        NumPad7 = 81,
        NumPad8 = 82,
        NumPad9 = 83,
        Multiply = 84,
        Add = 85,
        Separator = 86,
        Subtract = 87,
        Decimal = 88,
        Divide = 89,
        F1 = 90,
        F2 = 91,
        F3 = 92,
        F4 = 93,
        F5 = 94,
        F6 = 95,
        F7 = 96,
        F8 = 97,
        F9 = 98,
        F10 = 99,
        F11 = 100,
        F12 = 101,
        F13 = 102,
        F14 = 103,
        F15 = 104,
        F16 = 105,
        F17 = 106,
        F18 = 107,
        F19 = 108,
        F20 = 109,
        F21 = 110,
        F22 = 111,
        F23 = 112,
        F24 = 113,
        NumLock = 114,
        Scroll = 115,
        LeftShift = 116,
        RightShift = 117,
        LeftCtrl = 118,
        RightCtrl = 119,
        LeftAlt = 120,
        RightAlt = 121,
        BrowserBack = 122,
        BrowserForward = 123,
        BrowserRefresh = 124,
        BrowserStop = 125,
        BrowserSearch = 126,
        BrowserFavorites = 127,
        BrowserHome = 128,
        VolumeMute = 129,
        VolumeDown = 130,
        VolumeUp = 131,
        MediaNextTrack = 132,
        MediaPreviousTrack = 133,
        MediaStop = 134,
        MediaPlayPause = 135,
        LaunchMail = 136,
        SelectMedia = 137,
        LaunchApplication1 = 138,
        LaunchApplication2 = 139,
        OemSemicolon = 140,
        Oem1 = 140,
        OemPlus = 141,
        OemComma = 142,
        OemMinus = 143,
        OemPeriod = 144,
        OemQuestion = 145,
        Oem2 = 145,
        OemTilde = 146,
        Oem3 = 146,
        AbntC1 = 147,
        AbntC2 = 148,
        OemOpenBrackets = 149,
        Oem4 = 149,
        OemPipe = 150,
        Oem5 = 150,
        OemCloseBrackets = 151,
        Oem6 = 151,
        OemQuotes = 152,
        Oem7 = 152,
        Oem8 = 153,
        OemBackslash = 154,
        Oem102 = 154,
        ImeProcessed = 155,
        System = 156,
        OemAttn = 157,
        DbeAlphanumeric = 157,
        OemFinish = 158,
        DbeKatakana = 158,
        DbeHiragana = 159,
        OemCopy = 159,
        DbeSbcsChar = 160,
        OemAuto = 160,
        DbeDbcsChar = 161,
        OemEnlw = 161,
        OemBackTab = 162,
        DbeRoman = 162,
        DbeNoRoman = 163,
        Attn = 163,
        CrSel = 164,
        DbeEnterWordRegisterMode = 164,
        ExSel = 165,
        DbeEnterImeConfigureMode = 165,
        EraseEof = 166,
        DbeFlushString = 166,
        Play = 167,
        DbeCodeInput = 167,
        DbeNoCodeInput = 168,
        Zoom = 168,
        NoName = 169,
        DbeDetermineString = 169,
        DbeEnterDialogConversionMode = 170,
        Pa1 = 170,
        OemClear = 171,
        DeadCharProcessed = 172,
    }
}
