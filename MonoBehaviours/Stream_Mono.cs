using System;
using System.Collections.Generic;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using ModdingUtils.MonoBehaviours;
using ModdingUtils.Extensions;
using YCDRCards.Cards;

namespace YCDRCARDS.MonoBehaviours
{
    public class StreamMono : MonoBehaviour
    {

        private void ResetTimer()
        {
            this.startTime = Time.time;
        }

        private readonly float updateDelay = 0.1f;

        //
        public float startTime = Time.time;
        public void Update()
        {
            if (Time.time >= this.startTime + this.updateDelay)
            {
                this.ResetTimer();
                if (GetComponent<Player>().GetComponent<StreamBuffMono>() != null)
                {
                    GetComponent<Player>().GetComponent<StreamBuffMono>().Destroy();
                }
                GetComponent<Player>().transform.gameObject.AddComponent<StreamBuffMono>();
            }
        }

    }
        }
        
