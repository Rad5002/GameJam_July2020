using UnityEngine;

namespace Dogelix.Utils
{
    public static class StaticFunctions
    {
        /// <summary>
        /// This gets the distance between two points with the y value of the target set to the y of the start.
        /// </summary>
        /// <param name="start">From this position</param>
        /// <param name="target">To this position</param>
        /// <returns>Distance between points</returns>
        public static float DistanceToTarget( Vector3 start, Vector3 target )
        {
            return Vector3.Distance(( start - new Vector3(0, start.y, 0) ), target);
        }

        /// <summary>
        /// Returns the closest transform
        /// </summary>
        /// <param name="pawn">Transform of the pawn</param>
        /// <param name="targets">Transfoms of targets you want to check</param>
        /// <returns>Returns null if no enemies close</returns>
        public static Transform GetClosestTargets( Transform pawn, Transform[] targets )
        {
            Transform tMin = null;
            float minDist = Mathf.Infinity;
            Vector3 currentPos = pawn.position;
            foreach ( Transform t in targets )
            {
                float dist = Vector3.Distance(t.position, currentPos);
                if ( dist < minDist )
                {
                    tMin = t;
                    minDist = dist;
                }
            }
            return tMin;
        }

        /// <summary>
        /// Credit to whydoidoit
        /// https://answers.unity.com/users/21269/whydoidoit.html
        /// </summary>
        public static float ClampAngle( float angle, float min, float max )
        {
            angle = Mathf.Repeat(angle, 360);
            min = Mathf.Repeat(min, 360);
            max = Mathf.Repeat(max, 360);
            bool inverse = false;
            var tmin = min;
            var tangle = angle;
            if ( min > 180 )
            {
                inverse = !inverse;
                tmin -= 180;
            }
            if ( angle > 180 )
            {
                inverse = !inverse;
                tangle -= 180;
            }
            var result = !inverse ? tangle > tmin : tangle < tmin;
            if ( !result )
                angle = min;

            inverse = false;
            tangle = angle;
            var tmax = max;
            if ( angle > 180 )
            {
                inverse = !inverse;
                tangle -= 180;
            }
            if ( max > 180 )
            {
                inverse = !inverse;
                tmax -= 180;
            }

            result = !inverse ? tangle < tmax : tangle > tmax;
            if ( !result )
                angle = max;
            return angle;
        }

    }

}