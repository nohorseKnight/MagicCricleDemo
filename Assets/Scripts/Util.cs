namespace QFramework.Example
{
    public class Util
    {
        public static float LIGHT_DECREASE_ENEMY_DAMAGE = 0.8f;
        public static float FIRE_INCREASE_PLAYER_DAMAGE = 40f;
        public static float MOUNTAIN_DECREASE_ENMEY_DAMAGE = 40f;
        public static float PLANT_INCREASE_HP = 0.5f;
        public static float WATER_INCREASE_MP = 0.5f;
        public static float THUNDER_INCREASE_PLAYER_DAMAGE = 1.1f;
        public static float GROUND_PROBABILITY_AVOID_ENEMY_DAMAGE = 0.1f;

        public static float[,] elementTable = new float[9, 9]{
            {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f},
            {0.0f, 1.5f, 1.4f, 1.2f, 1.2f, 1.4f, 1.0f, 1.0f, 0.5f},
            {0.0f, 0.5f, 1.5f, 1.4f, 1.0f, 1.0f, 1.4f, 0.5f, 1.0f},
            {0.0f, 1.2f, 1.0f, 1.5f, 0.5f, 1.0f, 0.5f, 1.4f, 1.0f},
            {0.0f, 1.4f, 0.5f, 1.4f, 1.5f, 0.5f, 0.5f, 0.5f, 1.4f},
            {0.0f, 1.4f, 1.0f, 0.5f, 0.5f, 1.5f, 1.4f, 0.5f, 1.0f},
            {0.0f, 1.0f, 1.4f, 0.5f, 1.4f, 0.5f, 1.5f, 1.4f, 1.2f},
            {0.0f, 1.4f, 0.5f, 1.2f, 0.5f, 0.5f, 1.4f, 1.5f, 1.0f},
            {0.0f, 0.5f, 1.4f, 1.2f, 1.0f, 1.0f, 1.4f, 1.0f, 1.5f}
        };

        public static int CountStarValueByInterval(int[] arr)
        {
            int result = 0;
            result = arr[arr.Length - 2] + arr[0];
            if (result > arr[arr.Length - 1] + arr[1])
            {
                result = arr[arr.Length - 1] + arr[1];
            }
            for (int i = 0; i < arr.Length - 2; i++)
            {
                if (result > arr[i] + arr[i + 2])
                {
                    result = arr[i] + arr[i + 2];
                }
            }

            return result;
        }

        public static int CountStarValueByOrder(int[] arr)
        {
            int result = 0;
            result = arr[arr.Length - 1] + arr[0];
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (result > arr[i] + arr[i + 1])
                {
                    result = arr[i] + arr[i + 1];
                }
            }

            return result;
        }
    }
}