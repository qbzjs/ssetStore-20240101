﻿//Copyright 2022, Infima Games. All Rights Reserved.

using UnityEngine;

namespace InfimaGames.Animated.ModernGuns
{
    /// <summary>
    /// Bootstraper.
    /// </summary>
    public static class Bootstraper
    {
        /// <summary>
        /// Initialize.
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Initialize()
        {
            //Initialize default service locator.
            ServiceLocator.Initialize();
            
            //Game Mode Service.
            ServiceLocator.Current.Register<IGameModeService>(new GameModeService());
            //Game Start Service.
            ServiceLocator.Current.Register<IGameStartService>(new GameStartService());
            
            #region Sound Manager Service

            //Create an object for the sound manager, and add the component!
            var soundManagerObject = new GameObject("Sound Manager | Low Poly Animated - Modern Guns Pack");
            var soundManagerService = soundManagerObject.AddComponent<AudioManagerService>();
            
            //Make sure that we never destroy our SoundManager. We need it in other scenes too!
            Object.DontDestroyOnLoad(soundManagerObject);
            
            //Register the sound manager service!
            ServiceLocator.Current.Register<IAudioManagerService>(soundManagerService);

            #endregion
        }
    }
}