﻿using System;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using OnymojiAuto.Code.Model;
using OnymojiAuto.Code.Services;

namespace OnymojiAuto.Code.Scripts
{
    public class PartyQuest
    {
        private const string BACK_IN_BATTLE_POINT = "BACK_IN_BATTLE_POINT";
        private const string BACK_IN_WAITING_POINT = "BACK_IN_WAITING_POINT";
        private const string EMO_IN_WAITING_POINT = "EMO_IN_WAITING_POINT";
        private const string EXPLORER_POINT = "EXPLORER_POINT";
        private const string INVITE_PARTY_POINT = "INVITE_PARTY_POINT";
        private const string QUIT_IN_WAITING_POINT = "QUIT_IN_WAITING_POINT";

        public const string SCRIPT_NAME = "PartyQuest";

        public static string[] PartyQuestPoints =
        {
            BACK_IN_BATTLE_POINT,
            BACK_IN_WAITING_POINT,
            EMO_IN_WAITING_POINT,
            EXPLORER_POINT,
            INVITE_PARTY_POINT,
            QUIT_IN_WAITING_POINT
        };

        public static void Run()
        {
            Console.Clear();
            var backInBattlePoint = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, BACK_IN_BATTLE_POINT);
            var backInWaitingPoint = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, BACK_IN_WAITING_POINT);
            var emoInWaitingPoint = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, EMO_IN_WAITING_POINT);
            var explorerPoint = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, EXPLORER_POINT);
            var invitePartyPoint = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, INVITE_PARTY_POINT);
            var quitOkInWaitingPoint = ScriptHelper.getPointColorFromConfig(SCRIPT_NAME, QUIT_IN_WAITING_POINT);

            if (ScriptHelper.window.isCorrectPixelByRelatedPos(quitOkInWaitingPoint))
            {
                ScriptHelper.window.clickByRelatedCoor(quitOkInWaitingPoint);
            }
            else if (ScriptHelper.window.isCorrectPixelByRelatedPos(backInBattlePoint))
            {
                ScriptHelper.Log("In Battle");
                ScriptHelper.checkIdlSubject.OnNext(new { Type = "Runing", Time = DateTime.UtcNow.Ticks });
                if (!ScriptHelper.IS_TESTING)
                {
                }
            }
            else if (ScriptHelper.window.isCorrectPixelByRelatedPos(backInWaitingPoint))
            {
                if (ScriptHelper.window.isCorrectPixelByRelatedPos(emoInWaitingPoint))
                {
                    ScriptHelper.Log("Waiting");
                    if (!ScriptHelper.IS_TESTING)
                    {
                    }
                }
                else
                {
                    ScriptHelper.Log("Outed");
                    if (!ScriptHelper.IS_TESTING)
                    {
                        ScriptHelper.Log("Click Back");
                        ScriptHelper.window.clickByRelatedCoor(backInWaitingPoint);
                    }

                }
            }
            else if (ScriptHelper.window.isCorrectPixelByRelatedPos(explorerPoint))
            {
                ScriptHelper.Log("Explorer");
                if (ScriptHelper.window.isCorrectPixelByRelatedPos(invitePartyPoint))
                {
                    ScriptHelper.Log("Inviting");
                    if (!ScriptHelper.IS_TESTING)
                    {
                        ScriptHelper.Log("Click Accept");
                        ScriptHelper.window.clickByRelatedCoor(invitePartyPoint);
                    }
                }
            }
            else
            {
                ScriptHelper.Log("Spam");
                if (!ScriptHelper.IS_TESTING)
                {
                    ScriptHelper.Log("Click Spam");
                    ScriptHelper.window.clickByRelatedCoor(22.85106m, 7.95947m);
                }
            }
        }
    }
}