﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubing
{
    public abstract class FullCube : LastLayerCube
    {
        public FullCube()
        {
            UF = URF = UR = URB = UB = ULB = UL = ULF = Ucenter = CubeColor.Yellow;
            RUF = RU = RUB = RDF = RD = RDB = RF = RB = Rcenter = CubeColor.Green;
            BUR = BU = BUL = BDR = BD = BDL = BR = BL = Bcenter = CubeColor.Orange;
            LUF = LU = LUB = LDF = LD = LDB = LF = LB = Lcenter = CubeColor.Blue;
            FUR = FU = FUL = FDR = FD = FDL = FR = FL = Fcenter = CubeColor.Red;
            DF = DRF = DR = DRB = DB = DLB = DL = DLF = Dcenter = CubeColor.White;
        }

        public override void Solve()
        {
            UF = URF = UR = URB = UB = ULB = UL = ULF = Ucenter = CubeColor.Yellow;
            RUF = RU = RUB = RDF = RD = RDB = RF = RB = Rcenter = CubeColor.Green;
            BUR = BU = BUL = BDR = BD = BDL = BR = BL = Bcenter = CubeColor.Orange;
            LUF = LU = LUB = LDF = LD = LDB = LF = LB = Lcenter = CubeColor.Blue;
            FUR = FU = FUL = FDR = FD = FDL = FR = FL = Fcenter = CubeColor.Red;
            DF = DRF = DR = DRB = DB = DLB = DL = DLF = Dcenter = CubeColor.White;
        }

        public void SetUpPll(int num)
        {
            if (num < 48)                // adjacent corner swap
            {
                // for each case in a set of 12, execute a different PLL algorithm
                if (num % 12 == 0)
                    AaPerm();
                else if (num % 12 == 1)
                    AbPerm();
                else if (num % 12 == 2)
                    TPerm();
                else if (num % 12 == 3)
                    FPerm();
                else if (num % 12 == 4)
                    GaPerm();
                else if (num % 12 == 5)
                    GbPerm();
                else if (num % 12 == 6)
                    GcPerm();
                else if (num % 12 == 7)
                    GdPerm();
                else if (num % 12 == 8)
                    JaPerm();
                else if (num % 12 == 9)
                    JbPerm();
                else if (num % 12 == 10)
                    RaPerm();
                else
                    RbPerm();

                // num / 12 will determine the number of U moves which defines a specific corner permutation
                int uMoves = num / 12;
                while (uMoves > 0)
                {
                    U();
                    uMoves--;
                }
            }

            // diagonal corner swap
            else if ((num >= 52 && num < 60) || (num >= 64 && num < 72))
            {

                if (num < 56)
                    VPerm();
                else if (num < 60)
                    YPerm();
                else if (num < 68)
                    UaPerm();
                else if (num < 72)
                    UbPerm();
                int uMoves = num % 4;
                while (uMoves > 0)
                {
                    U();
                    uMoves--;
                }
            }

            // no corner swap
            else if (num == 48 || num == 49 || num == 62 || num == 63)
            {
                if (num < 50)
                    EPerm();
                else if (num < 64)
                    ZPerm();
                int uMoves = num % 2;
                while (uMoves > 0)
                {
                    U();
                    uMoves--;
                }
            }
            else
            {
                if (num == 50)
                    NaPerm();
                else if (num == 51)
                    NbPerm();
                else if (num == 60)
                    HPerm();
            }
        }
        
    }
}