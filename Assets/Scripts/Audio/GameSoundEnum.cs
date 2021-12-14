﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameSoundEnum{
    None,
    //Music
    Music_Main_Menu,
    Music_Level,
    Music_Level_Georgian,

    //UI
    UI_Button,

    //VO Orders English
    English_Order_Hamburger,
    English_Order_Hamburger_Lettuce,
    English_Order_Hamburger_Tomato,
    English_Order_Hamburger_Onion,
    English_Order_Hamburger_Lettuce_Tomato,
    English_Order_Hamburger_Lettuce_Onion,
    English_Order_Hamburger_Tomato_Onion,
    English_Order_Hamburger_Lettuce_Tomato_Onion,

    English_Order_Chicken_Doner,
    English_Order_Chicken_Doner_Lettuce,
    English_Order_Chicken_Doner_Tomato,
    English_Order_Chicken_Doner_Onion,
    English_Order_Chicken_Doner_Lettuce_Tomato,
    English_Order_Chicken_Doner_Lettuce_Onion,
    English_Order_Chicken_Doner_Tomato_Onion,
    English_Order_Chicken_Doner_Lettuce_Tomato_Onion,

    English_Thank_You,

    //VO Albanian Orders
    Albanian_Order_Hamburger,
    Albanian_Order_Hamburger_Lettuce,
    Albanian_Order_Hamburger_Tomato,
    Albanian_Order_Hamburger_Onion,
    Albanian_Order_Hamburger_Lettuce_Tomato,
    Albanian_Order_Hamburger_Lettuce_Onion,
    Albanian_Order_Hamburger_Tomato_Onion,
    Albanian_Order_Hamburger_Lettuce_Tomato_Onion,

    Albanian_Order_Chicken_Doner,
    Albanian_Order_Chicken_Doner_Lettuce,
    Albanian_Order_Chicken_Doner_Tomato,
    Albanian_Order_Chicken_Doner_Onion,
    Albanian_Order_Chicken_Doner_Lettuce_Tomato,
    Albanian_Order_Chicken_Doner_Lettuce_Onion,
    Albanian_Order_Chicken_Doner_Tomato_Onion,
    Albanian_Order_Chicken_Doner_Lettuce_Tomato_Onion,

    Albanian_Thank_You,

    

    //VO Study Cards English

    English_Hamburger,
    English_Chicken_Doner,
    English_Lettuce,
    English_Tomato,
    English_Onion,
    English_I_Would_Like_A,

    //VO Albanian Study Cards
    
    Albanian_Hamburger,
    Albanian_Chicken_Doner,
    Albanian_Lettuce,
    Albanian_Tomato,
    Albanian_Onion,
    Albanian_I_Would_Like_A,

    //SFX
    SFX_Customer_Impatience,
    SFX_Customer_Enter,
    SFX_Correct_Order,
    SFX_Incorrect_Order,


    //VO Georgian Orders
    Georgian_Order_Hamburger,
    Georgian_Order_Hamburger_Lettuce,
    Georgian_Order_Hamburger_Tomato,
    Georgian_Order_Hamburger_Onion,
    Georgian_Order_Hamburger_Lettuce_Tomato,
    Georgian_Order_Hamburger_Lettuce_Onion,
    Georgian_Order_Hamburger_Tomato_Onion,
    Georgian_Order_Hamburger_Lettuce_Tomato_Onion,

    Georgian_Order_Chicken_Doner,
    Georgian_Order_Chicken_Doner_Lettuce,
    Georgian_Order_Chicken_Doner_Tomato,
    Georgian_Order_Chicken_Doner_Onion,
    Georgian_Order_Chicken_Doner_Lettuce_Tomato,
    Georgian_Order_Chicken_Doner_Lettuce_Onion,
    Georgian_Order_Chicken_Doner_Tomato_Onion,
    Georgian_Order_Chicken_Doner_Lettuce_Tomato_Onion,

    Georgian_Thank_You,

    //VO Study Cards Georgian

    Georgian_Hamburger,
    Georgian_Chicken_Doner,
    Georgian_Lettuce,
    Georgian_Tomato,
    Georgian_Onion,
    Georgian_I_Would_Like_A,

    //English Phonics
    English_Phonic_A,
    English_Phonic_B,
    English_Phonic_C,
    English_Phonic_D,
    English_Phonic_E,
    English_Phonic_F,
    English_Phonic_G,
    English_Phonic_H,
    English_Phonic_I,
    English_Phonic_J,
    English_Phonic_K,
    English_Phonic_L,
    English_Phonic_M,
    English_Phonic_N,
    English_Phonic_O,
    English_Phonic_P,
    English_Phonic_Q,
    English_Phonic_R,
    English_Phonic_S,
    English_Phonic_T,
    English_Phonic_U,
    English_Phonic_V,
    English_Phonic_W,
    English_Phonic_X,
    English_Phonic_Y,
    English_Phonic_Z,

    Albanian_Phonic_A,
    Albanian_Phonic_B,
    Albanian_Phonic_C,
    Albanian_Phonic_D,
    Albanian_Phonic_DH,
    Albanian_Phonic_E,
    Albanian_Phonic_Ë,
    Albanian_Phonic_F,
    Albanian_Phonic_G,
    Albanian_Phonic_GJ,
    Albanian_Phonic_H,
    Albanian_Phonic_I,
    Albanian_Phonic_J,
    Albanian_Phonic_K,
    Albanian_Phonic_L,
    Albanian_Phonic_LL,
    Albanian_Phonic_M,
    Albanian_Phonic_N,
    Albanian_Phonic_NJ,
    Albanian_Phonic_O,
    Albanian_Phonic_P,
    Albanian_Phonic_Q,
    Albanian_Phonic_R,
    Albanian_Phonic_RR,
    Albanian_Phonic_S,
    Albanian_Phonic_T,
    Albanian_Phonic_TH,
    Albanian_Phonic_U,
    Albanian_Phonic_V,
    Albanian_Phonic_X,
    Albanian_Phonic_XH,
    Albanian_Phonic_Y,
    Albanian_Phonic_Z,
    Albanian_Phonic_ZH,

    Georgian_Phonic_ა,
    Georgian_Phonic_ბ,
    Georgian_Phonic_გ,
    Georgian_Phonic_დ,
    Georgian_Phonic_ე,
    Georgian_Phonic_ვ,
    Georgian_Phonic_ზ,
    Georgian_Phonic_თ,
    Georgian_Phonic_ი,
    Georgian_Phonic_კ,
    Georgian_Phonic_ლ,
    Georgian_Phonic_მ,
    Georgian_Phonic_ნ,
    Georgian_Phonic_ო,
    Georgian_Phonic_პ,
    Georgian_Phonic_ჟ,
    Georgian_Phonic_რ,
    Georgian_Phonic_ს,
    Georgian_Phonic_ტ,
    Georgian_Phonic_უ,
    Georgian_Phonic_ფ,
    Georgian_Phonic_ქ,
    Georgian_Phonic_ღ,
    Georgian_Phonic_ყ,
    Georgian_Phonic_შ,
    Georgian_Phonic_ჩ,
    Georgian_Phonic_ც,
    Georgian_Phonic_ძ,
    Georgian_Phonic_წ,
    Georgian_Phonic_ჭ,
    Georgian_Phonic_ხ,
    Georgian_Phonic_ჯ,
    Georgian_Phonic_ჰ,

    //Drink orders
    English_And_A_Water,
    English_And_A_Beer,
    English_And_A_Red_Wine,
    English_And_A_White_Wine,

    Albanian_And_A_Water,
    Albanian_And_A_Beer,
    Albanian_And_A_Red_Wine,
    Albanian_And_A_White_Wine,

    Georgian_And_A_Water,
    Georgian_And_A_Beer,
    Georgian_And_A_Red_Wine,
    Georgian_And_A_White_Wine,

    //more study cards
    English_Beer,
    Albanian_Beer,
    Georgian_Beer,

    English_Water,
    Albanian_Water,
    Georgian_Water,

    English_Red_Wine,
    Albanian_Red_Wine,
    Georgian_Red_Wine,

    English_White_Wine,
    Albanian_White_Wine,
    Georgian_White_Wine
}

