﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;

namespace NHibernate.Test.NHSpecificTest.NH2583
{
    using System.Threading.Tasks;
    using System.Threading;
    public partial class MyRef1
    {

        public virtual async Task<MyRef2> GetOrCreateBO2Async(ISession s, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (BO2 == null)
            {
                BO2 = new MyRef2();
                await (s.SaveAsync(BO2, cancellationToken));
            }
            return BO2;
        }

        public virtual async Task<MyRef3> GetOrCreateBO3Async(ISession s, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (BO3 == null)
            {
                BO3 = new MyRef3();
                await (s.SaveAsync(BO3, cancellationToken));
            }
            return BO3;
        }
    }

    public partial class MyBO
    {

        private async Task<MyRef1> GetOrCreateBO1Async(ISession s, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (BO1 == null)
            {
                BO1 = new MyRef1();
                await (s.SaveAsync(BO1, cancellationToken));
            }
            return BO1;
        }

        private async Task<MyRef2> GetOrCreateBO2Async(ISession s, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (BO2 == null)
            {
                BO2 = new MyRef2();
                await (s.SaveAsync(BO2, cancellationToken));
            }
            return BO2;
        }

        private static async Task SetBO1_IAsync(MyBO bo, ISession s, TBO1_I value, Action<MyRef1, int?> set, CancellationToken cancellationToken = default(CancellationToken))
        {
            switch (value)
            {
                case TBO1_I.Null:
                    bo.BO1 = null;
                    break;
                case TBO1_I.ValueNull:
                    set(await (bo.GetOrCreateBO1Async(s, cancellationToken)), null);
                    break;
                case TBO1_I.Zero:
                    set(await (bo.GetOrCreateBO1Async(s, cancellationToken)), 0);
                    break;
                case TBO1_I.One:
                    set(await (bo.GetOrCreateBO1Async(s, cancellationToken)), 1);
                    break;
                default:
                    throw new Exception("Value " + value + " not handled in code");
            }
        }

        private static async Task SetBO2_JAsync(MyBO bo, ISession s, TBO2_J value, Action<MyRef2, int?> set, CancellationToken cancellationToken = default(CancellationToken))
        {
            switch (value)
            {
                case TBO2_J.Null:
                    bo.BO2 = null;
                    break;
                case TBO2_J.ValueNull:
                    set(await (bo.GetOrCreateBO2Async(s, cancellationToken)), null);
                    break;
                case TBO2_J.Zero:
                    set(await (bo.GetOrCreateBO2Async(s, cancellationToken)), 0);
                    break;
                case TBO2_J.One:
                    set(await (bo.GetOrCreateBO2Async(s, cancellationToken)), 1);
                    break;
                default:
                    throw new Exception("Value " + value + " not handled in code");
            }
        }

        private static async Task SetBO1_BO2_JAsync(MyBO bo, ISession s, TBO1_BO2_J value, Action<MyRef2, int?> set, CancellationToken cancellationToken = default(CancellationToken))
        {
            switch (value)
            {
                case TBO1_BO2_J.Null:
                    bo.BO1 = null;
                    break;
                case TBO1_BO2_J.BO1:
                    (await (bo.GetOrCreateBO1Async(s, cancellationToken))).BO2 = null;
                    break;
                case TBO1_BO2_J.ValueNull:
                    set(await ((await (bo.GetOrCreateBO1Async(s, cancellationToken))).GetOrCreateBO2Async(s, cancellationToken)), null);
                    break;
                case TBO1_BO2_J.Zero:
                    set(await ((await (bo.GetOrCreateBO1Async(s, cancellationToken))).GetOrCreateBO2Async(s, cancellationToken)), 0);
                    break;
                case TBO1_BO2_J.One:
                    set(await ((await (bo.GetOrCreateBO1Async(s, cancellationToken))).GetOrCreateBO2Async(s, cancellationToken)), 1);
                    break;
                default:
                    throw new Exception("Value " + value + " not handled in code");
            }
        }

        public static async Task SetBO1_BO3_L1Async(MyBO bo, ISession s, TBO1_BO3_L value, CancellationToken cancellationToken = default(CancellationToken))
        {
            switch (value)
            {
                case TBO1_BO3_L.Null:
                    bo.BO1 = null;
                    break;
                case TBO1_BO3_L.BO1:
                    (await (bo.GetOrCreateBO1Async(s, cancellationToken))).BO3 = null;
                    break;
                case TBO1_BO3_L.ValueNull:
                    (await ((await (bo.GetOrCreateBO1Async(s, cancellationToken))).GetOrCreateBO3Async(s, cancellationToken))).L1 = 0; // L1 is int, not int?
                    break;
                case TBO1_BO3_L.Zero:
                    (await ((await (bo.GetOrCreateBO1Async(s, cancellationToken))).GetOrCreateBO3Async(s, cancellationToken))).L1 = 0;
                    break;
                case TBO1_BO3_L.One:
                    (await ((await (bo.GetOrCreateBO1Async(s, cancellationToken))).GetOrCreateBO3Async(s, cancellationToken))).L1 = 1;
                    break;
                default:
                    throw new Exception("Value " + value + " not handled in code");
            }
        }
    }
}
