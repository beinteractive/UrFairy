using UnityEngine;
using System.Collections;

namespace UrFairy
{
    public static class RandomExtensions
    {
        public static int RandomSign(this int n)
        {
            return n * (Random.value <= 0.5f ? 1 : -1);
        }

        public static float RandomSign(this float n)
        {
            return n * (Random.value <= 0.5f ? 1f : -1f);
        }
    }

    // PCG Random Number Generation

    public class Rnd
    {
        public Rnd() : this((ulong)(Random.value * ulong.MaxValue), (ulong)(Random.value * ulong.MaxValue))
        {
        }

        public Rnd(ulong iState, ulong iSeq)
        {
            state = 0U;
            inc = (iSeq << 1) | 1u;
            Next();
            state += iState;
            Next();
        }

        ulong state;
        ulong inc;

        uint Next()
        {
            ulong oldState = state;
            state = oldState * 6364136223846793005UL + inc;
            uint xorshifted = (uint)(((oldState >> 18) ^ oldState) >> 27);
            int rot = (int)(oldState >> 59);
            return (xorshifted >> rot) | (xorshifted << ((-rot) & 31));
        }

        uint Bounded(uint bound)
        {
            uint threshold = (uint)((0x100000000UL - bound) % bound);
            for (;;)
            {
                uint r = Next();
                if (r >= threshold)
                {
                    return r % bound;
                }
            }
        }

        public float Value { get { return Next() / (float)uint.MaxValue; } }
        public uint Value32 { get { return Next(); } }

        public float Range(float min, float max)
        {
            return min + Value * (max - min);
        }

        public int Range(int min, int max)
        {
            return min + (int)Bounded((uint)(max - min));
        }
    }
}