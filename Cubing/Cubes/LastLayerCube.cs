﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Cubing
{
    public abstract class LastLayerCube : AbstractCube
    {
        private double sizeRatio;

        public LastLayerCube()
        {
            Solve();
            sizeRatio = 1;
        }

        public LastLayerCube(int sizeRatio)
        {
            this.sizeRatio = sizeRatio;
        }



        public override void Paint(PaintEventArgs e)
        {
            Paint3D(e.Graphics, sizeRatio, 0, 0);
        }


        public void U()
        {
            CubeColor temp1 = URF;
            URF = URB;
            URB = ULB;
            ULB = ULF;
            ULF = temp1;
            CubeColor temp2 = RUF;
            RUF = BUR;
            BUR = LUB;
            LUB = FUL;
            FUL = temp2;
            CubeColor temp3 = FUR;
            FUR = RUB;
            RUB = BUL;
            BUL = LUF;
            LUF = temp3;
            CubeColor temp4 = UR;
            UR = UB;
            UB = UL;
            UL = UF;
            UF = temp4;
            CubeColor temp5 = RU;
            RU = BU;
            BU = LU;
            LU = FU;
            FU = temp5;
        }

        public void Ui()
        {
            U();
            U();
            U();
        }

        public void U2()
        {
            U();
            U();
        }

        

        

        /* set up a T orientation on the cube */
        public void TOrientation()
        {
            CubeColor temp1 = URB;
            URB = BUR;
            BUR = RUB;
            RUB = temp1;
            CubeColor temp2 = ULB;
            ULB = BUL;
            BUL = LUB;
            LUB = temp2;
        }

        /* set up a U orientation on the cube */
        public void UOrientation()
        {
            TOrientation();
            TOrientation();
        }

        /* set up an L orientation on the cube */
        public void LOrientation()
        {
            UOrientation();
            U();
            UOrientation();
            Ui();
        }

        /* set up a sune orientation on the cube */
        public void SuneOrientation()
        {
            TOrientation();
            U();
            UOrientation();
            Ui();
        }

        /* set up an antisune orientation on the cube */
        public void AntisuneOrientation()
        {
            TOrientation();
            Ui();
            UOrientation();
            U();
        }

        /* set up a pi orientation on the cube */
        public void PiOrientation()
        {
            Ui();
            TOrientation();
            U2();
            UOrientation();
            Ui();
        }

        /* set up an H orientation on the cube */
        public void HOrientation()
        {
            TOrientation();
            U2();
            TOrientation();
            U2();
        }

        /* Flip the back edge */
        private void FlipB()
        {
            CubeColor temp = BU;
            BU = UB;
            UB = temp;
        }

        /* Flip the right and back edges */
        public void FlipRB()
        {
            FlipB();
            Ui();
            FlipB();
            U();
        }

        /* Flip the left and back edges */
        public void FlipLB()
        {
            FlipB();
            U();
            FlipB();
            Ui();
        }

        /* Flip the front and back edges */
        public void FlipFB()
        {
            FlipB();
            U2();
            FlipB();
            U2();
        }

        /* Flip the left and front edges */
        public void FlipLF()
        {
            U2();
            FlipRB();
            U2();
        }

        /* Flip the right and front edges */
        public void FlipRF()
        {
            U2();
            FlipLB();
            U2();
        }

        /* Flip the right and left edges */
        public void FlipRL()
        {
            U();
            FlipFB();
            Ui();
        }

        /* Flip all top layer edges */
        public void FlipAll()
        {
            FlipRB();
            FlipLF();
        }

        /* swap the right 2 corners */
        public void RightSwap()
        {
            TPerm();
        }

        /* swap the left 2 corners */
        public void LeftSwap()
        {
            U2();
            RightSwap();
            U2();
        }

        /* swap the front 2 corners */
        public void FrontSwap()
        {
            Ui();
            RightSwap();
            U();
        }

        /* swap the back 2 corners */
        public void BackSwap()
        {
            U();
            RightSwap();
            Ui();
        }

        /* swap 2 diagonal corners */
        public void DiagSwap()
        {
            FrontSwap();
            BackSwap();
        }

        /* execute a random move with the U face */
        public void RandomUMove()
        {
            Random rand = new Random();
            int num = rand.Next(4);
            while (num > 0)
            {
                U();
                num--;
            }
        }

        /* execute a Ua permutation */
        public void UaPerm()
        {
            CubeColor temp1 = LU;
            LU = RU;
            RU = FU;
            FU = temp1;
            CubeColor temp2 = UL;
            UL = UR;
            UR = UF;
            UF = temp2;

        }

        /* execute a Ub permutation */
        public void UbPerm()
        {
            CubeColor temp1 = LU;
            LU = RU;
            RU = BU;
            BU = temp1;
            CubeColor temp2 = UL;
            UL = UR;
            UR = UB;
            UB = temp2;
        }

        /* execute an H permutation */
        public void HPerm()
        {
            UaPerm();
            U();
            UaPerm();
            Ui();
        }

        /* execute a Z permutation */
        public void ZPerm()
        {
            UaPerm();
            UbPerm();
        }

        /* execute an Aa permutation */
        public void AaPerm()
        {
            CubeColor temp1 = URF;
            URF = URB;
            URB = ULB;
            ULB = temp1;
            CubeColor temp2 = RUF;
            RUF = BUR;
            BUR = LUB;
            LUB = temp2;
            CubeColor temp3 = FUR;
            FUR = RUB;
            RUB = BUL;
            BUL = temp3;
            U2();
        }

        /* execute an Ab permutation */
        public void AbPerm()
        {
            AaPerm();
            U2();
            AaPerm();
            U();
        }

        /* execute a Ga permutation */
        public void GaPerm()
        {
            U();
            AaPerm();
            Ui();
            UaPerm();
            U();
        }

        /* execute a Gb permutation */
        public void GbPerm()
        {
            GaPerm();
            GaPerm();
            GaPerm();
        }

        /* execute a Gc permutation */
        public void GcPerm()
        {
            GdPerm();
            GdPerm();
            GdPerm();
        }

        /* execute a Gd permutation */
        public void GdPerm()
        {
            U();
            AaPerm();
            U2();
            UaPerm();
            U2();
        }

        /* execute a Ja permutation */
        public void JaPerm()
        {
            GbPerm();
            HPerm();
        }

        /* execute a Jb permutation */
        public void JbPerm()
        {
            GcPerm();
            HPerm();
        }

        /* execute an Ra permutation */
        public void RaPerm()
        {
            GaPerm();
            HPerm();
        }

        /* execute an Rb permutation */
        public void RbPerm()
        {
            GdPerm();
            HPerm();
        }

        /* execute a T permutation */
        public void TPerm()
        {
            U();
            AaPerm();
            Ui();
            ZPerm();
            U();
        }

        /* execute an F permutation */
        public void FPerm()
        {
            U();
            AaPerm();
            ZPerm();
        }

        /* execute a V permutation */
        public void VPerm()
        {
            Ui();
            YPerm();
            HPerm();
            Ui();
        }

        /* execute a Y permutation */
        public void YPerm()
        {
            U();
            JbPerm();
            U2();
            JaPerm();
            U2();
        }

        /* execute an E permutation */
        public void EPerm()
        {
            U();
            AbPerm();
            AbPerm();
            U();
        }

        /* execute an Na permutation */
        public void NaPerm()
        {
            JbPerm();
            U2();
            JbPerm();
            Ui();
        }

        /* execute an Nb permutation */
        public void NbPerm()
        {
            JaPerm();
            U2();
            JaPerm();
            U();
        }



        //public abstract void SetUpPosition(int posNum);

        //public abstract int GetPosNum();

        public abstract void Solve();

        public bool LastLayerMatch(LastLayerCube other)
        {
            ColorCompare? curr = null;
            Tuple<bool, ColorCompare?> value = RecognitionTools.IsMatch(this.URF, other.URF, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.URF, other.URF, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.FUR, other.FUR, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.RUF, other.RUF, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.ULF, other.ULF, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.LUF, other.LUF, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.FUL, other.FUL, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.URB, other.URB, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.RUB, other.RUB, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.BUR, other.BUR, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.ULB, other.ULB, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.LUB, other.LUB, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.BUL, other.BUL, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.UF, other.UF, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.FU, other.FU, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.UL, other.UL, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.LU, other.LU, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.UB, other.UB, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.BU, other.BU, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.UR, other.UR, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            value = RecognitionTools.IsMatch(this.RU, other.RU, curr);
            if (value.Item1 == false)
                return false;
            curr = value.Item2;
            return true;

        }

        public void Orient()
        {
            if(RUF == CubeColor.Yellow)
            { 
                RUF = FUR;
                FUR = URF;
                URF = CubeColor.Yellow;
            }
            else if(FUR == CubeColor.Yellow)
            {
                FUR = RUF;
                RUF = URF;
                URF = CubeColor.Yellow;
            }
            if(RUB == CubeColor.Yellow)
            {
                RUB = BUR;
                BUR = URB;
                URB = CubeColor.Yellow;
            }
            else if(BUR == CubeColor.Yellow)
            {
                BUR = RUB;
                RUB = URB;
                URB = CubeColor.Yellow;
            }
            if(LUB == CubeColor.Yellow)
            {
                LUB = BUL;
                BUL = ULB;
                ULB = CubeColor.Yellow;
            }
            else if(BUL == CubeColor.Yellow)
            {
                BUL = LUB;
                LUB = ULB;
                ULB = CubeColor.Yellow;
            }
            if(LUF == CubeColor.Yellow)
            {
                LUF = FUL;
                FUL = ULF;
                ULF = CubeColor.Yellow;
            }
            else if(FUL == CubeColor.Yellow)
            {
                FUL = LUF;
                LUF = ULF;
                ULF = CubeColor.Yellow;
            }
            if(RU == CubeColor.Yellow)
            {
                RU = UR;
                UR = CubeColor.Yellow;
            }
            if(BU == CubeColor.Yellow)
            {
                BU = UB;
                UB = CubeColor.Yellow;
            }
            if(FU == CubeColor.Yellow)
            {
                FU = UF;
                UF = CubeColor.Yellow;
            }
            if(LU == CubeColor.Yellow)
            {
                LU = UL;
                UL = CubeColor.Yellow;
            }
        }


        //public bool Equals(LastLayerCube other)
        //{

        //}
        public int GetCornerOrientationNum()
        {
            int numOriented = 0;
            if (URF == CubeColor.Yellow)
                numOriented++;
            if (ULF == CubeColor.Yellow)
                numOriented++;
            if (URB == CubeColor.Yellow)
                numOriented++;
            if (ULB == CubeColor.Yellow)
                numOriented++;

            if (numOriented == 2)
            {
                // U case
                if ((FUR == CubeColor.Yellow && FUL == CubeColor.Yellow) || (RUF == CubeColor.Yellow && RUB == CubeColor.Yellow)
                    || (BUR == CubeColor.Yellow && BUL == CubeColor.Yellow) || (LUF == CubeColor.Yellow && LUB == CubeColor.Yellow))
                    return 1;
                // L case
                else if ((URF == CubeColor.Yellow && ULB == CubeColor.Yellow) || (URB == CubeColor.Yellow && ULF == CubeColor.Yellow))
                    return 2;
                else
                    return 0;
            }
            else if (numOriented == 1)
            {
                // sune
                if (FUR == CubeColor.Yellow || RUB == CubeColor.Yellow)
                    return 3;
                else
                    return 4;
            }
            else if (numOriented == 0)
            {
                // H case
                if ((FUR == CubeColor.Yellow && BUL == CubeColor.Yellow) || (RUF == CubeColor.Yellow && LUB == CubeColor.Yellow))
                    return 6;
                else
                    return 5;
            }
            else
                return 7;

        }

        public int GetEdgeOrientationNum()
        {
            if (RU == CubeColor.Yellow && BU == CubeColor.Yellow && LU != CubeColor.Yellow)
                return 0;
            if (LU == CubeColor.Yellow && BU == CubeColor.Yellow && RU != CubeColor.Yellow)
                return 1;
            if (RU == CubeColor.Yellow && FU == CubeColor.Yellow && LU != CubeColor.Yellow)
                return 2;
            if (LU == CubeColor.Yellow && FU == CubeColor.Yellow && RU != CubeColor.Yellow)
                return 3;
            if (FU == CubeColor.Yellow && BU == CubeColor.Yellow && RU != CubeColor.Yellow)
                return 4;
            if (RU == CubeColor.Yellow && LU == CubeColor.Yellow && FU != CubeColor.Yellow)
                return 5;
            if (RU == CubeColor.Yellow && LU == CubeColor.Yellow && FU == CubeColor.Yellow)
                return 6;
            if (RU != CubeColor.Yellow && LU != CubeColor.Yellow && FU != CubeColor.Yellow)
                return 7;
            return -1;
        }

        


    }
}