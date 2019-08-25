using UnityEngine;
using UnityEngine.UI;

namespace CoolBattleRoyaleZone
{
    /// <summary>
    /// Class which controls showing the timer of zone
    /// </summary>

    public class ShowZoneTime : MonoBehaviour
    {
        public Text TimeText;

        public WaypointManager wpm;
        public Zone zone;

        bool init = true;
        public float minST = 20;
        public float maxST = 30;
        

        // Method for showing shrinking timer
        public void ShowShrinkingTime ( Zone.Timer timer )
        {
            TimeText.text = "<color=red>"                                           + "ZONE SHRINKING: \n <b>" +
                            ( timer.EndTime - timer.CurrentTime ).ToString ( "F0" ) + "</b></color>";
        }

        // Method for clearing text on end of last circle/step
        public void EndOfLastStep ( Zone.Timer timer ) { TimeText.text = ""; }

        // Method for showing waiting timer before shrinking
        public void ShowWaitingTime ( Zone.Timer timer )
        {
            TimeText.text = "ZONE SHRINKS IN: \n"                                   + "<b><color=red>" +
                            ( timer.EndTime - timer.CurrentTime ).ToString ( "F0" ) + "</color></b>";
        
            if (timer.EndTime - timer.CurrentTime < 5 && init)
            {
                init = false;
                for (int i = 0; i < zone.ZoneCircles.Count; i++)
                {
                    float dif = maxST - minST;
                    float prct = (float)(zone.ZoneCircles.Count - i) / (zone.ZoneCircles.Count);
                    float st = dif * prct + minST;
                    
                    if (i == zone.ZoneCircles.Count - 1)
                        zone.ZoneCircles[i].ShrinkingTime = 0;
                    else
                        zone.ZoneCircles[i].ShrinkingTime = st;
                    
                }
            }
            
            
            if (timer.EndTime - timer.CurrentTime <= 0)
            {
                wpm.zoneCenter = zone.ZoneCircles[zone.CurStep].PositionAndRadius.Position;
                wpm.RefreshWaypoints();
            }
        }
    }
}
