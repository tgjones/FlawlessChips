namespace FlawlessChips;

partial class Flawless6502
{
    public static class NodeIds
    {
        public const NodeId res = 159;       // pads: reset
        public const NodeId rw = 1156;       // pads: read not write
        public const NodeId db0 = 1005;      // pads: databus
        public const NodeId db1 = 82;
        public const NodeId db3 = 650;
        public const NodeId db2 = 945;
        public const NodeId db5 = 175;
        public const NodeId db4 = 1393;
        public const NodeId db7 = 1349;
        public const NodeId db6 = 1591;
        public const NodeId ab0 = 268;       // pads: address bus
        public const NodeId ab1 = 451;
        public const NodeId ab2 = 1340;
        public const NodeId ab3 = 211;
        public const NodeId ab4 = 435;
        public const NodeId ab5 = 736;
        public const NodeId ab6 = 887;
        public const NodeId ab7 = 1493;
        public const NodeId ab8 = 230;
        public const NodeId ab9 = 148;
        public const NodeId ab12 = 1237;
        public const NodeId ab13 = 349;
        public const NodeId ab10 = 1443;
        public const NodeId ab11 = 399;
        public const NodeId ab14 = 672;
        public const NodeId ab15 = 195;
        public const NodeId sync = 539;      // pads
        public const NodeId so = 1672;       // pads: set overflow
        public const NodeId clk0 = 1171;     // pads
        public const NodeId clk1out = 1163;  // pads
        public const NodeId clk2out = 421;   // pads
        public const NodeId rdy = 89;        // pads: ready
        public const NodeId nmi = 1297;      // pads: non maskable interrupt
        public const NodeId irq = 103;       // pads
        public const NodeId vcc = 657;       // pads
        public const NodeId vss = 558;       // pads

        public const NodeId a0 = 737;        // machine state: accumulator
        public const NodeId a1 = 1234;
        public const NodeId a2 = 978;
        public const NodeId a3 = 162;
        public const NodeId a4 = 727;
        public const NodeId a5 = 858;
        public const NodeId a6 = 1136;
        public const NodeId a7 = 1653;
        public const NodeId y0 = 64;         // machine state: y index register
        public const NodeId y1 = 1148;
        public const NodeId y2 = 573;
        public const NodeId y3 = 305;
        public const NodeId y4 = 989;
        public const NodeId y5 = 615;
        public const NodeId y6 = 115;
        public const NodeId y7 = 843;
        public const NodeId x0 = 1216;       // machine state: x index register
        public const NodeId x1 = 98;
        public const NodeId x2 = 1;
        public const NodeId x3 = 1648;
        public const NodeId x4 = 85;
        public const NodeId x5 = 589;
        public const NodeId x6 = 448;
        public const NodeId x7 = 777;
        public const NodeId pcl0 = 1139;     // machine state: program counter low (first storage node output)
        public const NodeId pcl1 = 1022;
        public const NodeId pcl2 = 655;
        public const NodeId pcl3 = 1359;
        public const NodeId pcl4 = 900;
        public const NodeId pcl5 = 622;
        public const NodeId pcl6 = 377;
        public const NodeId pcl7 = 1611;
        public const NodeId pclp0 = 488;    // machine state: program counter low (pre-incremented?, second storage node)
        public const NodeId pclp1 = 976;
        public const NodeId pclp2 = 481;
        public const NodeId pclp3 = 723;
        public const NodeId pclp4 = 208;
        public const NodeId pclp5 = 72;
        public const NodeId pclp6 = 1458;
        public const NodeId pclp7 = 1647;
        public const NodeId hash_pclp0 = 1227;    // machine state: program counter low (pre-incremented?, inverse second storage node)
        public const NodeId tilde_pclp0 = 1227;     // automatic alias replacing hash with tilde
        public const NodeId hash_pclp1 = 1102;
        public const NodeId tilde_pclp1 = 1102; // automatic alias replacing hash with tilde
        public const NodeId hash_pclp2 = 1079;
        public const NodeId tilde_pclp2 = 1079; // automatic alias replacing hash with tilde
        public const NodeId hash_pclp3 = 868;
        public const NodeId tilde_pclp3 = 868; // automatic alias replacing hash with tilde
        public const NodeId hash_pclp4 = 39;
        public const NodeId tilde_pclp4 = 39; // automatic alias replacing hash with tilde
        public const NodeId hash_pclp5 = 1326;
        public const NodeId tilde_pclp5 = 1326; // automatic alias replacing hash with tilde
        public const NodeId hash_pclp6 = 731;
        public const NodeId tilde_pclp6 = 731; // automatic alias replacing hash with tilde
        public const NodeId hash_pclp7 = 536;
        public const NodeId tilde_pclp7 = 536; // automatic alias replacing hash with tilde
        public const NodeId pch0 = 1670;     // machine state: program counter high (first storage node)
        public const NodeId pch1 = 292;
        public const NodeId pch2 = 502;
        public const NodeId pch3 = 584;
        public const NodeId pch4 = 948;
        public const NodeId pch5 = 49;
        public const NodeId pch6 = 1551;
        public const NodeId pch7 = 205;
        public const NodeId pchp0 = 1722;     // machine state: program counter high (pre-incremented?, second storage node output)
        public const NodeId pchp1 = 209;
        public const NodeId pchp2 = 1496;
        public const NodeId pchp3 = 141;
        public const NodeId pchp4 = 27;
        public const NodeId pchp5 = 1301;
        public const NodeId pchp6 = 652;
        public const NodeId pchp7 = 1206;
        public const NodeId hash_pchp0 = 780;     // machine state: program counter high (pre-incremented?, inverse second storage node)
        public const NodeId tilde_pchp0 = 780;      // automatic alias replacing hash with tilde
        public const NodeId hash_pchp1 = 113;
        public const NodeId tilde_pchp1 = 113; // automatic alias replacing hash with tilde
        public const NodeId hash_pchp2 = 114;
        public const NodeId tilde_pchp2 = 114; // automatic alias replacing hash with tilde
        public const NodeId hash_pchp3 = 124;
        public const NodeId tilde_pchp3 = 124; // automatic alias replacing hash with tilde
        public const NodeId hash_pchp4 = 820;
        public const NodeId tilde_pchp4 = 820; // automatic alias replacing hash with tilde
        public const NodeId hash_pchp5 = 33;
        public const NodeId tilde_pchp5 = 33; // automatic alias replacing hash with tilde
        public const NodeId hash_pchp6 = 751;
        public const NodeId tilde_pchp6 = 751; // automatic alias replacing hash with tilde
        public const NodeId hash_pchp7 = 535;
        public const NodeId tilde_pchp7 = 535; // automatic alias replacing hash with tilde
                // machine state: status register (not the storage nodes)
        public const NodeId p0 = 32;         // C bit of status register (storage node)
        public const NodeId p1 = 627;        // Z bit of status register (storage node)
        public const NodeId p2 = 1553;       // I bit of status register (storage node)
        public const NodeId p3 = 348;        // D bit of status register (storage node)
        public const NodeId p4 = 1119;       // there is no bit4 in the status register! (not a storage node)
        public const NodeId p5 = NodeId.MaxValue;         // there is no bit5 in the status register! (not a storage node)
        public const NodeId p6 = 1625;       // V bit of status register (storage node)
        public const NodeId p7 = 69;         // N bit of status register (storage node)

                // internal bus: status register outputs for push P
        public const NodeId Pout0 = 687;
        public const NodeId Pout1 = 1444;
        public const NodeId Pout2 = 1421;
        public const NodeId Pout3 = 439;
        public const NodeId Pout4 = 1119;    // there is no bit4 in the status register!
        public const NodeId Pout5 = NodeId.MaxValue;      // there is no bit5 in the status register!
        public const NodeId Pout6 = 77;
        public const NodeId Pout7 = 1370;

        public const NodeId s0 = 1403;       // machine state: stack pointer
        public const NodeId s1 = 183;
        public const NodeId s2 = 81;
        public const NodeId s3 = 1532;
        public const NodeId s4 = 1702;
        public const NodeId s5 = 1098;
        public const NodeId s6 = 1212;
        public const NodeId s7 = 1435;
        public const NodeId ir0 = 328;       // internal state: instruction register
        public const NodeId ir1 = 1626;
        public const NodeId ir2 = 1384;
        public const NodeId ir3 = 1576;
        public const NodeId ir4 = 1112;
        public const NodeId ir5 = 1329;      // ir5 distinguishes branch set from branch clear
        public const NodeId ir6 = 337;
        public const NodeId ir7 = 1328;
        public const NodeId notir0 = 194;    // internal signal: instruction register inverted outputs
        public const NodeId notir1 = 702;
        public const NodeId notir2 = 1182;  
        public const NodeId notir3 = 1125;  
        public const NodeId notir4 = 26;
        public const NodeId notir5 = 1394;
        public const NodeId notir6 = 895;
        public const NodeId notir7 = 1320;
        public const NodeId irline3 = 996;   // internal signal: PLA input - ir0 OR ir1
        public const NodeId clock1 = 1536;   // internal state: timing control aka #T0
        public const NodeId clock2 = 156;    // internal state: timing control aka #T+
        public const NodeId t2 = 971;        // internal state: timing control
        public const NodeId t3 = 1567;
        public const NodeId t4 = 690;
        public const NodeId t5 = 909;
        public const NodeId noty0 = 1025;    // datapath state: not Y register
        public const NodeId noty1 = 1138;
        public const NodeId noty2 = 1484;
        public const NodeId noty3 = 184;
        public const NodeId noty4 = 565;
        public const NodeId noty5 = 981;
        public const NodeId noty6 = 1439;
        public const NodeId noty7 = 1640;
        public const NodeId notx0 = 987;     // datapath state: not X register
        public const NodeId notx1 = 1434;
        public const NodeId notx2 = 890;
        public const NodeId notx3 = 1521;
        public const NodeId notx4 = 485;
        public const NodeId notx5 = 1017;
        public const NodeId notx6 = 730;
        public const NodeId notx7 = 1561;
        public const NodeId nots0 = 418;     // datapath state: not stack pointer
        public const NodeId nots1 = 1064;
        public const NodeId nots2 = 752;
        public const NodeId nots3 = 828;
        public const NodeId nots4 = 1603;
        public const NodeId nots5 = 601;
        public const NodeId nots6 = 1029;
        public const NodeId nots7 = 181;
        public const NodeId notidl0 = 116;   // datapath state: internal data latch (first storage node)
        public const NodeId notidl1 = 576;
        public const NodeId notidl2 = 1485;
        public const NodeId notidl3 = 1284;
        public const NodeId notidl4 = 1516;
        public const NodeId notidl5 = 498;
        public const NodeId notidl6 = 1537;
        public const NodeId notidl7 = 529;
        public const NodeId idl0 = 1597;     // datapath signal: internal data latch (driven output)
        public const NodeId idl1 = 870;
        public const NodeId idl2 = 1066;
        public const NodeId idl3 = 464;
        public const NodeId idl4 = 1306;
        public const NodeId idl5 = 240;
        public const NodeId idl6 = 1116;
        public const NodeId idl7 = 391;
        public const NodeId sb0 = 54;        // datapath bus: special bus
        public const NodeId sb1 = 1150;
        public const NodeId sb2 = 1287;
        public const NodeId sb3 = 1188;
        public const NodeId sb4 = 1405;
        public const NodeId sb5 = 166;
        public const NodeId sb6 = 1336;
        public const NodeId sb7 = 1001;
        public const NodeId notalu0 = 394;   // datapath state: alu output storage node (inverse) aka #ADD0
        public const NodeId notalu1 = 697;
        public const NodeId notalu2 = 276;
        public const NodeId notalu3 = 495;
        public const NodeId notalu4 = 1490;
        public const NodeId notalu5 = 893;
        public const NodeId notalu6 = 68;
        public const NodeId notalu7 = 1123;
        public const NodeId alu0 = 401;      // datapath signal: ALU output aka ADD0out
        public const NodeId alu1 = 872;
        public const NodeId alu2 = 1637;
        public const NodeId alu3 = 1414;
        public const NodeId alu4 = 606;
        public const NodeId alu5 = 314;
        public const NodeId alu6 = 331;
        public const NodeId alu7 = 765;
		// datapath signal: decimally adjusted special bus
        public const NodeId dasb0 = 54;      // same node as sb0
        public const NodeId dasb1 = 1009;
        public const NodeId dasb2 = 450;
        public const NodeId dasb3 = 1475;
        public const NodeId dasb4 = 1405;    // same node as sb4
        public const NodeId dasb5 = 263;
        public const NodeId dasb6 = 679;
        public const NodeId dasb7 = 1494;
        public const NodeId adl0 = 413;      // internal bus: address low
        public const NodeId adl1 = 1282;
        public const NodeId adl2 = 1242;
        public const NodeId adl3 = 684;
        public const NodeId adl4 = 1437;
        public const NodeId adl5 = 1630;
        public const NodeId adl6 = 121;
        public const NodeId adl7 = 1299;
        public const NodeId adh0 = 407;      // internal bus: address high
        public const NodeId adh1 = 52;
        public const NodeId adh2 = 1651;
        public const NodeId adh3 = 315;
        public const NodeId adh4 = 1160;
        public const NodeId adh5 = 483;
        public const NodeId adh6 = 13;
        public const NodeId adh7 = 1539;
        public const NodeId idb0 = 1108;     // internal bus: data bus
        public const NodeId idb1 = 991;
        public const NodeId idb2 = 1473;
        public const NodeId idb3 = 1302;
        public const NodeId idb4 = 892;
        public const NodeId idb5 = 1503;
        public const NodeId idb6 = 833;
        public const NodeId idb7 = 493;
        public const NodeId notdor0 = 222;   // internal state: data output register (storage node)
        public const NodeId notdor1 = 527;
        public const NodeId notdor2 = 1288;
        public const NodeId notdor3 = 823;
        public const NodeId notdor4 = 873;
        public const NodeId notdor5 = 1266;
        public const NodeId notdor6 = 1418;
        public const NodeId notdor7 = 158;
        public const NodeId dor0 = 97;       // internal signal: data output register
        public const NodeId dor1 = 746;
        public const NodeId dor2 = 1634;
        public const NodeId dor3 = 444;
        public const NodeId dor4 = 1088;
        public const NodeId dor5 = 1453;
        public const NodeId dor6 = 1415;
        public const NodeId dor7 = 63;
        public const NodeId pd0_clearIR = 1622;       // internal state: predecode register output (anded with not ClearIR)
        public const NodeId pd1_clearIR = 809;
        public const NodeId pd2_clearIR = 1671;
        public const NodeId pd3_clearIR = 1587;
        public const NodeId pd4_clearIR = 540;
        public const NodeId pd5_clearIR = 667;
        public const NodeId pd6_clearIR = 1460;
        public const NodeId pd7_clearIR = 1410;
        public const NodeId pd0 = 758;       // internal state: predecode register (storage node)
        public const NodeId pd1 = 361;
        public const NodeId pd2 = 955;
        public const NodeId pd3 = 894;
        public const NodeId pd4 = 369;
        public const NodeId pd5 = 829;
        public const NodeId pd6 = 1669;
        public const NodeId pd7 = 1690;
                // internal signals: predecode latch partial decodes
        public const NodeId PD_xxxx10x0 = 1019;
        public const NodeId PD_1xx000x0 = 1294;
        public const NodeId PD_0xx0xx0x = 365;
        public const NodeId PD_xxx010x1 = 302;
        public const NodeId PD_n_0xx0xx0x = 125;
        public const NodeId hash_TWOCYCLE = 851;
        public const NodeId tilde_TWOCYCLE = 851; // automatic alias replacing hash with tilde
        public const NodeId hash_TWOCYCLE_phi1 = 792;
        public const NodeId tilde_TWOCYCLE_phi1 = 792; // automatic alias replacing hash with tilde
        public const NodeId ONEBYTE = 778;

        public const NodeId abl0 = 1096;     // internal bus: address bus low latched data out (inverse of inverted storage node)
        public const NodeId abl1 = 376;
        public const NodeId abl2 = 1502;
        public const NodeId abl3 = 1250;
        public const NodeId abl4 = 1232;
        public const NodeId abl5 = 234;
        public const NodeId abl6 = 178;
        public const NodeId abl7 = 567;
        public const NodeId hash_ABL0 = 153;   // internal state: address bus low latched data out (storage node, inverted)
        public const NodeId tilde_ABL0 = 153;    // automatic alias replacing hash with tilde
        public const NodeId hash_ABL1 = 107;
        public const NodeId tilde_ABL1 = 107; // automatic alias replacing hash with tilde
        public const NodeId hash_ABL2 = 707;
        public const NodeId tilde_ABL2 = 707; // automatic alias replacing hash with tilde
        public const NodeId hash_ABL3 = 825;
        public const NodeId tilde_ABL3 = 825; // automatic alias replacing hash with tilde
        public const NodeId hash_ABL4 = 364;
        public const NodeId tilde_ABL4 = 364; // automatic alias replacing hash with tilde
        public const NodeId hash_ABL5 = 1513;
        public const NodeId tilde_ABL5 = 1513; // automatic alias replacing hash with tilde
        public const NodeId hash_ABL6 = 1307;
        public const NodeId tilde_ABL6 = 1307; // automatic alias replacing hash with tilde
        public const NodeId hash_ABL7 = 28;
        public const NodeId tilde_ABL7 = 28; // automatic alias replacing hash with tilde
        public const NodeId abh0 = 1429;     // internal bus: address bus high latched data out (inverse of inverted storage node)
        public const NodeId abh1 = 713;
        public const NodeId abh2 = 287;
        public const NodeId abh3 = 422;
        public const NodeId abh4 = 1143;
        public const NodeId abh5 = 775;
        public const NodeId abh6 = 997;
        public const NodeId abh7 = 489;
        public const NodeId hash_ABH0 = 1062;  // internal state: address bus high latched data out (storage node, inverted)
        public const NodeId tilde_ABH0 = 1062;   // automatic alias replacing hash with tilde
        public const NodeId hash_ABH1 = 907;
        public const NodeId tilde_ABH1 = 907; // automatic alias replacing hash with tilde
        public const NodeId hash_ABH2 = 768;
        public const NodeId tilde_ABH2 = 768; // automatic alias replacing hash with tilde
        public const NodeId hash_ABH3 = 92;
        public const NodeId tilde_ABH3 = 92; // automatic alias replacing hash with tilde
        public const NodeId hash_ABH4 = 668;
        public const NodeId tilde_ABH4 = 668; // automatic alias replacing hash with tilde
        public const NodeId hash_ABH5 = 1128;
        public const NodeId tilde_ABH5 = 1128; // automatic alias replacing hash with tilde
        public const NodeId hash_ABH6 = 289;
        public const NodeId tilde_ABH6 = 289; // automatic alias replacing hash with tilde
        public const NodeId hash_ABH7 = 429;
        public const NodeId tilde_ABH7 = 429; // automatic alias replacing hash with tilde

        public const NodeId branch_back = 626;           // distinguish forward from backward branches
        public const NodeId branch_forward_phi1 = 1110;  // distinguish forward from backward branches
        public const NodeId branch_back_phi1 = 771;      // distinguish forward from backward branches in IPC logic
        public const NodeId notRdy0 = 248;           // internal signal: global pipeline control
        public const NodeId notRdy0_phi1 = 1272;   // delayed pipeline control
        public const NodeId notRdy0_delay = 770;   // global pipeline control latched by phi1 and then phi2
        public const NodeId hash_notRdy0_delay = 559;  // global pipeline control latched by phi1 and then phi2 (storage node)
        public const NodeId tilde_notRdy0_delay = 559;   // automatic alias replacing hash with tilde
        public const NodeId Reset0 = 67;     // internal signal: retimed reset from pin
        public const NodeId C1x5Reset = 926; // retimed and pipelined reset in progress
        public const NodeId notRnWprepad = 187; // internal signal: to pad, yet to be inverted and retimed
        public const NodeId RnWstretched = 353; // internal signal: control datapad output drivers, aka TRISTATE
        public const NodeId hash_DBE = 1035;      // internal signal: formerly from DBE pad (6501)
        public const NodeId tilde_DBE = 1035;       // automatic alias replacing hash with tilde
        public const NodeId cp1 = 710;       // internal signal: clock phase 1
        public const NodeId cclk = 943;      // unbonded pad: internal non-overlapping phi2
        public const NodeId fetch = 879;     // internal signal
        public const NodeId clearIR = 1077;  // internal signal
        public const NodeId H1x1 = 1042;     // internal signal: drive status byte onto databus

                // internal signal: pla outputs block 1 (west/left edge of die)
                // often 130 pla outputs are mentioned - we have 131 here
        public const NodeId op_sty_cpy_mem = 1601;        // pla0
        public const NodeId op_T3_ind_y = 60;             // pla1
        public const NodeId op_T2_abs_y = 1512;           // pla2
        public const NodeId op_T0_iny_dey = 382;          // pla3
        public const NodeId x_op_T0_tya = 1173;           // pla4
        public const NodeId op_T0_cpy_iny = 1233;         // pla5

                // internal signal: pla outputs block 2
        public const NodeId op_T2_idx_x_xy = 258;         // pla6
        public const NodeId op_xy = 1562;                 // pla7
        public const NodeId op_T2_ind_x = 84;             // pla8
        public const NodeId x_op_T0_txa = 1543;           // pla9
        public const NodeId op_T0_dex = 76;               // pla10
        public const NodeId op_T0_cpx_inx = 1658;         // pla11
        public const NodeId op_from_x = 1540;             // pla12
        public const NodeId op_T0_txs = 245;              // pla13
        public const NodeId op_T0_ldx_tax_tsx = 985;      // pla14
        public const NodeId op_T_plus__dex = 786;              // pla15
        public const NodeId op_T_plus__inx = 1664;             // pla16
        public const NodeId op_T0_tsx = 682;              // pla17
        public const NodeId op_T_plus__iny_dey = 1482;         // pla18
        public const NodeId op_T0_ldy_mem = 665;          // pla19
        public const NodeId op_T0_tay_ldy_not_idx = 286;  // pla20

                // internal signal: pla outputs block 3
                // not pla, feed through
        public const NodeId op_T0_jsr = 271;              // pla21
        public const NodeId op_T5_brk = 370;              // pla22
        public const NodeId op_T0_php_pha = 552;          // pla23
        public const NodeId op_T4_rts = 1612;             // pla24
        public const NodeId op_T3_plp_pla = 1487;         // pla25
        public const NodeId op_T5_rti = 784;              // pla26
        public const NodeId op_ror = 244;                 // pla27
        public const NodeId op_T2 = 788;                  // pla28
        public const NodeId op_T0_eor = 1623;             // pla29
        public const NodeId op_jmp = 764;                 // pla30
        public const NodeId op_T2_abs = 1057;             // pla31
        public const NodeId op_T0_ora = 403;              // pla32
        public const NodeId op_T2_ADL_ADD = 204;           // pla33 
        public const NodeId op_T0 = 1273;                  // pla34 
        public const NodeId op_T2_stack = 1582;            // pla35 
        public const NodeId op_T3_stack_bit_jmp = 1031;    // pla36 

                // internal signal: pla outputs block 4
        public const NodeId op_T4_brk_jsr = 804;           //  pla37
        public const NodeId op_T4_rti = 1311;              //  pla38
        public const NodeId op_T3_ind_x = 1428;            //  pla39
        public const NodeId op_T4_ind_y = 492;             //  pla40
        public const NodeId op_T2_ind_y = 1204;            //  pla41
        public const NodeId op_T3_abs_idx = 58;            //  pla42
        public const NodeId op_plp_pla = 1520;             //  pla43
        public const NodeId op_inc_nop = 324;              //  pla44
        public const NodeId op_T4_ind_x = 1259;            //  pla45
        public const NodeId x_op_T3_ind_y = 342;           //  pla46
        public const NodeId op_rti_rts = 857;              //  pla47
        public const NodeId op_T2_jsr = 712;               //  pla48
        public const NodeId op_T0_cpx_cpy_inx_iny = 1337;  //  pla49
        public const NodeId op_T0_cmp = 1355;              //  pla50
        public const NodeId op_T0_sbc = 787;               //  pla51   //  52:111XXXXX  1  0  T0SBC
        public const NodeId op_T0_adc_sbc = 575;           //  pla52   //  51:X11XXXXX  1  0  T0ADCSBC
        public const NodeId op_rol_ror = 1466;             //  pla53

                // internal signal: pla outputs block 5
        public const NodeId op_T3_jmp = 1381;              //  pla54
        public const NodeId op_shift = 546;                //  pla55
        public const NodeId op_T5_jsr = 776;               //  pla56
        public const NodeId op_T2_stack_access = 157;      //  pla57
        public const NodeId op_T0_tya = 257;               //  pla58
        public const NodeId op_T_plus__ora_and_eor_adc = 1243;  //  pla59
        public const NodeId op_T_plus__adc_sbc = 822;           //  pla60
        public const NodeId op_T_plus__shift_a = 1324;          //  pla61
        public const NodeId op_T0_txa = 179;               //  pla62
        public const NodeId op_T0_pla = 131;               //  pla63
        public const NodeId op_T0_lda = 1420;              //  pla64
        public const NodeId op_T0_acc = 1342;              //  pla65
        public const NodeId op_T0_tay = 4;                 //  pla66
        public const NodeId op_T0_shift_a = 1396;          //  pla67
        public const NodeId op_T0_tax = 167;               //  pla68
        public const NodeId op_T0_bit = 303;               //  pla69
        public const NodeId op_T0_and = 1504;              //  pla70
        public const NodeId op_T4_abs_idx = 354;           //  pla71
        public const NodeId op_T5_ind_y = 1168;            //  pla72

                // internal signal: pla outputs block 6
        public const NodeId op_branch_done = 1721;         //  pla73    // has extra non-pla input
        public const NodeId op_T2_pha = 1086;              //  pla74
        public const NodeId op_T0_shift_right_a = 1074;    //  pla75
        public const NodeId op_shift_right = 1246;         //  pla76
        public const NodeId op_T2_brk = 487;               //  pla77
        public const NodeId op_T3_jsr = 579;               //  pla78
        public const NodeId op_sta_cmp = 145;              //  pla79
        public const NodeId op_T2_branch = 1239;           //  pla80      //  T2BR, 83 for Balazs
        public const NodeId op_T2_zp_zp_idx = 285;         //  pla81
                // not pla, feed through
                // not pla, feed through
        public const NodeId op_T2_ind = 1524;              //  pla82
        public const NodeId op_T2_abs_access = 273;        //  pla83      // has extra pulldown: pla97
        public const NodeId op_T5_rts = 0;                 //  pla84
        public const NodeId op_T4 = 341;                   //  pla85
        public const NodeId op_T3 = 120;                   //  pla86
        public const NodeId op_T0_brk_rti = 1478;          //  pla87
        public const NodeId op_T0_jmp = 594;               //  pla88
        public const NodeId op_T5_ind_x = 1210;            //  pla89
        public const NodeId op_T3_abs_idx_ind = 677;       //  pla90      // has extra pulldown: pla97

                // internal signal: pla outputs block 7
        public const NodeId x_op_T4_ind_y = 461;           //  pla91
        public const NodeId x_op_T3_abs_idx = 447;         //  pla92
        public const NodeId op_T3_branch = 660;            //  pla93
        public const NodeId op_brk_rti = 1557;             //  pla94
        public const NodeId op_jsr = 259;                  //  pla95
        public const NodeId x_op_jmp = 1052;               //  pla96
                // gap
        public const NodeId op_push_pull = 791;            //  pla97      // feeds into pla83 and pla90 (no normal pla output)
        public const NodeId op_store = 517;                //  pla98
        public const NodeId op_T4_brk = 352;               //  pla99
        public const NodeId op_T2_php = 750;               //  pla100
        public const NodeId op_T2_php_pha = 932;           //  pla101
        public const NodeId op_T4_jmp = 1589;              //  pla102
                // gap
        public const NodeId op_T5_rti_rts = 446;           //  pla103
        public const NodeId xx_op_T5_jsr = 528;            //  pla104

                // internal signal: pla outputs block 8
        public const NodeId op_T2_jmp_abs = 309;           //  pla105
        public const NodeId x_op_T3_plp_pla = 1430;        //  pla106
        public const NodeId op_lsr_ror_dec_inc = 53;       //  pla107
        public const NodeId op_asl_rol = 691;              //  pla108
        public const NodeId op_T0_cli_sei = 1292;          //  pla109
                // gap
        public const NodeId op_T_plus__bit = 1646;              //  pla110
        public const NodeId op_T0_clc_sec = 1114;          //  pla111
        public const NodeId op_T3_mem_zp_idx = 904;        //  pla112
        public const NodeId x_op_T_plus__adc_sbc = 1155;        //  pla113
        public const NodeId x_op_T0_bit = 1476;            //  pla114
        public const NodeId op_T0_plp = 1226;              //  pla115
        public const NodeId x_op_T4_rti = 1569;            //  pla116
        public const NodeId op_T_plus__cmp = 301;               //  pla117
        public const NodeId op_T_plus__cpx_cpy_abs = 950;       //  pla118
        public const NodeId op_T_plus__asl_rol_a = 1665;        //  pla119

                // internal signal: pla outputs block 9
        public const NodeId op_T_plus__cpx_cpy_imm_zp = 1710;   //  pla120
        public const NodeId x_op_push_pull = 1050;         //  pla121    // feeds into pla130 (no normal pla output)
        public const NodeId op_T0_cld_sed = 1419;          //  pla122
        public const NodeId hash_op_branch_bit6 = 840;         //  pla123    // IR bit6 used only to detect branch type
        public const NodeId tilde_op_branch_bit6 = 840;          // automatic alias replacing hash with tilde
        public const NodeId op_T3_mem_abs = 607;           //  pla124
        public const NodeId op_T2_mem_zp = 219;            //  pla125
        public const NodeId op_T5_mem_ind_idx = 1385;      //  pla126
        public const NodeId op_T4_mem_abs_idx = 281;       //  pla127
        public const NodeId hash_op_branch_bit7 = 1174;        //  pla128    // IR bit7 used only to detect branch type
        public const NodeId tilde_op_branch_bit7 = 1174;         // automatic alias replacing hash with tilde
        public const NodeId op_clv = 1164;                 //  pla129
        public const NodeId op_implied = 1006;             //  pla130    // has extra pulldowns: pla121 and ir0

// internal signals: derived from pla outputs
        public const NodeId hash_op_branch_done = 1048;
        public const NodeId tilde_op_branch_done = 1048; // automatic alias replacing hash with tilde
        public const NodeId hash_op_T3_branch = 1708;
        public const NodeId tilde_op_T3_branch = 1708; // automatic alias replacing hash with tilde
        public const NodeId op_ANDS = 1228;
        public const NodeId op_EORS = 1689;
        public const NodeId op_ORS = 522;
        public const NodeId op_SUMS = 1196;
        public const NodeId op_SRS = 934;
        public const NodeId hash_op_store = 925;
        public const NodeId tilde_op_store = 925; // automatic alias replacing hash with tilde
        public const NodeId hash_WR = 1352;
        public const NodeId tilde_WR = 1352; // automatic alias replacing hash with tilde
        public const NodeId op_rmw = 434;
        public const NodeId short_circuit_idx_add = 1185;
        public const NodeId short_circuit_branch_add = 430;
        public const NodeId hash_op_set_C = 252;
        public const NodeId tilde_op_set_C = 252; // automatic alias replacing hash with tilde

// internal signals: control signals
        public const NodeId nnT2BR = 967;    // doubly inverted
        public const NodeId hash_BRtaken = 1544;  // aka #TAKEN
        public const NodeId tilde_BRtaken = 1544;   // automatic alias replacing hash with tilde

// internal signals and state: interrupt and vector related
// segher says:
//   P" are the latched external signals.
//   G" are the signals that actually trigger the interrupt.
//   NMIL" is to do the edge detection -- it's pretty much just a delayed NMIG.
//   INTG is IRQ and NMI taken together.
        public const NodeId IRQP = 675;
        public const NodeId hash_IRQP = 888;
        public const NodeId tilde_IRQP = 888; // automatic alias replacing hash with tilde
        public const NodeId NMIP = 1032;
        public const NodeId hash_NMIP = 297;
        public const NodeId tilde_NMIP = 297; // automatic alias replacing hash with tilde
        public const NodeId hash_NMIG = 264;
        public const NodeId tilde_NMIG = 264; // automatic alias replacing hash with tilde
        public const NodeId NMIL = 1374;
        public const NodeId RESP = 67;
        public const NodeId RESG = 926;
        public const NodeId VEC0 = 1465;
        public const NodeId VEC1 = 1481;
        public const NodeId hash_VEC = 1134;
        public const NodeId tilde_VEC = 1134; // automatic alias replacing hash with tilde
        public const NodeId D1x1 = 827;         // internal signal: interrupt handler related
        public const NodeId brk_done = 1382;  // internal signal: interrupt handler related
        public const NodeId INTG = 1350;        // internal signal: interrupt handler related

// internal state: misc pipeline state clocked by cclk (phi2)
        public const NodeId pipe_hash_VEC = 1431;     // latched #VEC
        public const NodeId pipe_tilde_VEC = 1431;      // automatic alias replacing hash with tilde
        public const NodeId pipeT_SYNC = 537;
        public const NodeId pipeT2out = 40;
        public const NodeId pipeT3out = 706;
        public const NodeId pipeT4out = 1373;
        public const NodeId pipeT5out = 940;
        public const NodeId pipeIPCrelated = 832;
        public const NodeId pipeUNK01 = 1530;
        public const NodeId pipeUNK02 = 974;
        public const NodeId pipeUNK03 = 1436;
        public const NodeId pipeUNK04 = 99;
        public const NodeId pipeUNK05 = 44;
        public const NodeId pipeUNK06 = 443;
        public const NodeId pipeUNK07 = 215;
        public const NodeId pipeUNK08 = 338;
        public const NodeId pipeUNK09 = 199;
        public const NodeId pipeUNK10 = 215;
        public const NodeId pipeUNK11 = 1011;
        public const NodeId pipeUNK12 = 1283;
        public const NodeId pipeUNK13 = 1442;
        public const NodeId pipeUNK14 = 1607;
        public const NodeId pipeUNK15 = 1577; // inverse of H1x1, write P onto idb (PHP, interrupt)
        public const NodeId pipeUNK16 = 1051;
        public const NodeId pipeUNK17 = 1078;
        public const NodeId pipeUNK18 = 899;
        public const NodeId pipeUNK19 = 832;
        public const NodeId pipeUNK20 = 294;
        public const NodeId pipeUNK21 = 1176;
        public const NodeId pipeUNK22 = 561; // becomes dpc22
        public const NodeId pipeUNK23 = 596;
        public const NodeId pipephi2Reset0 = 449;
        public const NodeId pipephi2Reset0x = 1036; // a second copy of the same latch
        public const NodeId pipeUNK26 = 1321;
        public const NodeId pipeUNK27 = 73;
        public const NodeId pipeUNK28 = 685;
        public const NodeId pipeUNK29 = 1008;
        public const NodeId pipeUNK30 = 1652;
        public const NodeId pipeUNK31 = 614;
        public const NodeId pipeUNK32 = 960;
        public const NodeId pipeUNK33 = 848;
        public const NodeId pipeUNK34 = 56;
        public const NodeId pipeUNK35 = 1713;
        public const NodeId pipeUNK36 = 729;
        public const NodeId pipeUNK37 = 197;
        public const NodeId pipe_hash_WR_phi2 = 1131;
        public const NodeId pipe_tilde_WR_phi2 = 1131; // automatic alias replacing hash with tilde
        public const NodeId pipeUNK39 = 151;
        public const NodeId pipeUNK40 = 456;
        public const NodeId pipeUNK41 = 1438;
        public const NodeId pipeUNK42 = 1104;
        public const NodeId pipe_hash_T0 = 554;   // aka #T0.phi2
        public const NodeId pipe_tilde_T0 = 554;    // automatic alias replacing hash with tilde

// internal state: vector address pulldown control
        public const NodeId pipeVectorA0 = 357;
        public const NodeId pipeVectorA1 = 170;
        public const NodeId pipeVectorA2 = 45;

// internal signals: vector address pulldown control
        public const NodeId _0_ADL0 = 217;
        public const NodeId _0_ADL1 = 686;
        public const NodeId _0_ADL2 = 1193;

// internal state: datapath control drivers
        public const NodeId pipedpc28 = 683;

// internal signals: alu internal (private) busses
        public const NodeId alua0 = 1167;
        public const NodeId alua1 = 1248;
        public const NodeId alua2 = 1332;
        public const NodeId alua3 = 1680;
        public const NodeId alua4 = 1142;
        public const NodeId alua5 = 530;
        public const NodeId alua6 = 1627;
        public const NodeId alua7 = 1522;
        public const NodeId alub0 = 977;
        public const NodeId alub1 = 1432;
        public const NodeId alub2 = 704;
        public const NodeId alub3 = 96;
        public const NodeId alub4 = 1645;
        public const NodeId alub5 = 1678;
        public const NodeId alub6 = 235;
        public const NodeId alub7 = 1535;

// alu carry chain and decimal mode
        public const NodeId C01 = 1285;
        public const NodeId C12 = 505;
        public const NodeId C23 = 1023;
        public const NodeId C34 = 78;
        public const NodeId C45 = 142;
        public const NodeId C56 = 500;
        public const NodeId C67 = 1314;
        public const NodeId C78 = 808;
        public const NodeId C78_phi2 = 560;
        public const NodeId DC34 = 1372;   // lower nibble decimal carry
        public const NodeId DC78 = 333;    // carry for decimal mode
        public const NodeId DC78_phi2 = 164;
        public const NodeId hash_C01 = 1506;
        public const NodeId tilde_C01 = 1506; // automatic alias replacing hash with tilde
        public const NodeId hash_C12 = 1122;
        public const NodeId tilde_C12 = 1122; // automatic alias replacing hash with tilde
        public const NodeId hash_C23 = 1003;
        public const NodeId tilde_C23 = 1003; // automatic alias replacing hash with tilde
        public const NodeId hash_C34 = 1425;
        public const NodeId tilde_C34 = 1425; // automatic alias replacing hash with tilde
        public const NodeId hash_C45 = 1571;
        public const NodeId tilde_C45 = 1571; // automatic alias replacing hash with tilde
        public const NodeId hash_C56 = 427;
        public const NodeId tilde_C56 = 427; // automatic alias replacing hash with tilde
        public const NodeId hash_C67 = 592;
        public const NodeId tilde_C67 = 592; // automatic alias replacing hash with tilde
        public const NodeId hash_C78 = 1327;
        public const NodeId tilde_C78 = 1327; // automatic alias replacing hash with tilde
        public const NodeId DA_C01 = 623;
        public const NodeId DA_AB2 = 216;
        public const NodeId DA_AxB2 = 516;
        public const NodeId DA_C45 = 1144;
        public const NodeId hash_DA_ADD1 = 901;
        public const NodeId tilde_DA_ADD1 = 901; // automatic alias replacing hash with tilde
        public const NodeId hash_DA_ADD2 = 699;
        public const NodeId tilde_DA_ADD2 = 699; // automatic alias replacing hash with tilde

// misc alu internals
        public const NodeId hash_gs_AxBxC_ge_0 = 371;
        public const NodeId tilde_gs_AxBxC_ge_0 = 371; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxBxC_ge_1 = 965;
        public const NodeId tilde_gs_AxBxC_ge_1 = 965; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxBxC_ge_2 = 22;
        public const NodeId tilde_gs_AxBxC_ge_2 = 22; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxBxC_ge_3 = 274;
        public const NodeId tilde_gs_AxBxC_ge_3 = 274; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxBxC_ge_4 = 651;
        public const NodeId tilde_gs_AxBxC_ge_4 = 651; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxBxC_ge_5 = 486;
        public const NodeId tilde_gs_AxBxC_ge_5 = 486; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxBxC_ge_6 = 1197;
        public const NodeId tilde_gs_AxBxC_ge_6 = 1197; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxBxC_ge_7 = 532;
        public const NodeId tilde_gs_AxBxC_ge_7 = 532; // automatic alias replacing hash with tilde
        public const NodeId AxB1 = 425;
        public const NodeId AxB3 = 640;
        public const NodeId AxB5 = 1220;
        public const NodeId AxB7 = 1241;
        public const NodeId hash_gs_AxB_ge_0 = 1525;
        public const NodeId tilde_gs_AxB_ge_0 = 1525; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB_ge_2 = 701;
        public const NodeId tilde_gs_AxB_ge_2 = 701; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB_ge_4 = 308;
        public const NodeId tilde_gs_AxB_ge_4 = 308; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB_ge_6 = 1459;
        public const NodeId tilde_gs_AxB_ge_6 = 1459; // automatic alias replacing hash with tilde
        public const NodeId gs_AxB_ge_0_hash_C0in = 555;
        public const NodeId gs_AxB_ge_0_tilde_C0in = 555; // automatic alias replacing hash with tilde
        public const NodeId gs_AxB_ge_2_hash_C12 = 193;
        public const NodeId gs_AxB_ge_2_tilde_C12 = 193; // automatic alias replacing hash with tilde
        public const NodeId gs_AxB_ge_4_plus_hash_C34 = 65;
        public const NodeId gs_AxB_ge_4_tilde_C34 = 65; // automatic alias replacing hash with tilde
        public const NodeId gs_AxB_ge_6_hash_C56 = 174;
        public const NodeId gs_AxB_ge_6_tilde_C56 = 174; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB1_ge_C01 = 295;
        public const NodeId tilde_gs_AxB1_ge_C01 = 295; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB3_ge_C23 = 860;
        public const NodeId tilde_gs_AxB3_ge_C23 = 860; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB5_ge_C45 = 817;
        public const NodeId tilde_gs_AxB5_ge_C45 = 817; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB7_ge_C67 = 1217;
        public const NodeId tilde_gs_AxB7_ge_C67 = 1217; // automatic alias replacing hash with tilde
        public const NodeId hash_A_B0 = 1628;
        public const NodeId tilde_A_B0 = 1628; // automatic alias replacing hash with tilde
        public const NodeId hash_A_B1 = 841;
        public const NodeId tilde_A_B1 = 841; // automatic alias replacing hash with tilde
        public const NodeId hash_A_B2 = 681;
        public const NodeId tilde_A_B2 = 681; // automatic alias replacing hash with tilde
        public const NodeId hash_A_B3 = 350;
        public const NodeId tilde_A_B3 = 350; // automatic alias replacing hash with tilde
        public const NodeId hash_A_B4 = 1063;
        public const NodeId tilde_A_B4 = 1063; // automatic alias replacing hash with tilde
        public const NodeId hash_A_B5 = 477;
        public const NodeId tilde_A_B5 = 477; // automatic alias replacing hash with tilde
        public const NodeId hash_A_B6 = 336;
        public const NodeId tilde_A_B6 = 336; // automatic alias replacing hash with tilde
        public const NodeId hash_A_B7 = 1318;
        public const NodeId tilde_A_B7 = 1318; // automatic alias replacing hash with tilde
        public const NodeId A_plus_B0 = 693;
        public const NodeId A_plus_B1 = 1021;
        public const NodeId A_plus_B2 = 110;
        public const NodeId A_plus_B3 = 1313;
        public const NodeId A_plus_B4 = 918;
        public const NodeId A_plus_B5 = 1236;
        public const NodeId A_plus_B6 = 803;
        public const NodeId A_plus_B7 = 117;
        public const NodeId hash_gs_A_plus_B_ge_0 = 143;
        public const NodeId tilde_gs_A_plus_B_ge_0 = 143; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_A_plus_B_ge_1 = 155;
        public const NodeId tilde_gs_A_plus_B_ge_1 = 155; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_A_plus_B_ge_2 = 1691;
        public const NodeId tilde_gs_A_plus_B_ge_2 = 1691; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_A_plus_B_ge_3 = 649;
        public const NodeId tilde_gs_A_plus_B_ge_3 = 649; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_A_plus_B_ge_4 = 404;
        public const NodeId tilde_gs_A_plus_B_ge_4 = 404; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_A_plus_B_ge_5 = 1632;
        public const NodeId tilde_gs_A_plus_B_ge_5 = 1632; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_A_plus_B_ge_6 = 1084;
        public const NodeId tilde_gs_A_plus_B_ge_6 = 1084; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_A_plus_B_ge_7 = 1398;
        public const NodeId tilde_gs_A_plus_B_ge_7 = 1398; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB_ge_1 = 953;
        public const NodeId tilde_gs_AxB_ge_1 = 953; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB_ge_3 = 884;
        public const NodeId tilde_gs_AxB_ge_3 = 884; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB_ge_5 = 1469;
        public const NodeId tilde_gs_AxB_ge_5 = 1469; // automatic alias replacing hash with tilde
        public const NodeId hash_gs_AxB_ge_7 = 177;
        public const NodeId tilde_gs_AxB_ge_7 = 177; // automatic alias replacing hash with tilde
        public const NodeId hash_aluresult0 = 957;   // alu result latch input
        public const NodeId tilde_aluresult0 = 957;    // automatic alias replacing hash with tilde
        public const NodeId hash_aluresult1 = 250;
        public const NodeId tilde_aluresult1 = 250; // automatic alias replacing hash with tilde
        public const NodeId hash_aluresult2 = 740;
        public const NodeId tilde_aluresult2 = 740; // automatic alias replacing hash with tilde
        public const NodeId hash_aluresult3 = 1071;
        public const NodeId tilde_aluresult3 = 1071; // automatic alias replacing hash with tilde
        public const NodeId hash_aluresult4 = 296;
        public const NodeId tilde_aluresult4 = 296; // automatic alias replacing hash with tilde
        public const NodeId hash_aluresult5 = 277;
        public const NodeId tilde_aluresult5 = 277; // automatic alias replacing hash with tilde
        public const NodeId hash_aluresult6 = 722;
        public const NodeId tilde_aluresult6 = 722; // automatic alias replacing hash with tilde
        public const NodeId hash_aluresult7 = 304;
        public const NodeId tilde_aluresult7 = 304; // automatic alias replacing hash with tilde

// internal signals: datapath control signals

        public const NodeId ADL_ABL = 639;      // load ABL latches from ADL bus
        public const NodeId dpc_1_ADL_ABL = 639;// alias for DPControl pseudo-bus

        public const NodeId ADH_ABH = 821;      // load ABH latches from ADH bus
        public const NodeId dpc_2_ADH_ABH = 821;// alias for DPControl pseudo-bus

        public const NodeId dpc0_YSB = 801;       // drive sb from y
        public const NodeId dpc1_SBY = 325;       // load y from sb
        public const NodeId dpc2_XSB = 1263;      // drive sb from x
        public const NodeId dpc3_SBX = 1186;      // load x from sb
        public const NodeId dpc4_SSB = 1700;      // drive sb from stack pointer
        public const NodeId dpc5_SADL = 1468;     // drive adl from stack pointer
        public const NodeId dpc6_SBS = 874;       // load stack pointer from sb
        public const NodeId dpc7_SS = 654;        // recirculate stack pointer
        public const NodeId dpc8_nDBADD = 1068;   // alu b side: select not-idb input
        public const NodeId dpc9_DBADD = 859;     // alu b side: select idb input

        public const NodeId dpc10_ADLADD = 437;   // alu b side: select adl input
        public const NodeId dpc11_SBADD = 549;    // alu a side: select sb
        public const NodeId dpc12_0ADD = 984;     // alu a side: select zero
        public const NodeId dpc13_ORS = 59;       // alu op: a or b
        public const NodeId dpc14_SRS = 362;      // alu op: logical right shift
        public const NodeId dpc15_ANDS = 574;     // alu op: a and b
        public const NodeId dpc16_EORS = 1666;    // alu op: a xor b (?)
        public const NodeId dpc17_SUMS = 921;     // alu op: a plus b (?)
        public const NodeId alucin = 910;         // alu carry in
        public const NodeId notalucin = 1165;
        public const NodeId dpc18__hash_DAA = 1201;  // decimal related (inverted)
        public const NodeId dpc18_tilde_DAA = 1201;   // automatic alias replacing hash with tilde
        public const NodeId dpc19_ADDSB7 = 214;   // alu to sb bit 7 only

        public const NodeId dpc20_ADDSB06 = 129;  // alu to sb bits 6-0 only
        public const NodeId dpc21_ADDADL = 1015;  // alu to adl
        public const NodeId alurawcout = 808;     // alu raw carry out (no decimal adjust)
        public const NodeId notalucout = 412;     // alu carry out (inverted)
        public const NodeId alucout = 1146;       // alu carry out (latched by phi2)
        public const NodeId hash_alucout = 206;
        public const NodeId tilde_alucout = 206; // automatic alias replacing hash with tilde
        public const NodeId hash__hash_alucout = 465;
        public const NodeId tilde_tilde_alucout = 465; // automatic alias replacing hash with tilde
        public const NodeId notaluvout = 1308;    // alu overflow out
        public const NodeId aluvout = 938;        // alu overflow out (latched by phi2)

        public const NodeId hash_DBZ = 1268;   // internal signal: not (databus is zero)
        public const NodeId tilde_DBZ = 1268;    // automatic alias replacing hash with tilde
        public const NodeId DBZ = 744;       // internal signal: databus is zero
        public const NodeId DBNeg = 1200;    // internal signal: databus is negative (top bit of db) aka P-#DB7in

        public const NodeId dpc22__hash_DSA = 725;   // decimal related/SBC only (inverted)
        public const NodeId dpc22_tilde_DSA = 725;    // automatic alias replacing hash with tilde
        public const NodeId dpc23_SBAC = 534;     // (optionalls decimal-adjusted) sb to acc
        public const NodeId dpc24_ACSB = 1698;    // acc to sb
        public const NodeId dpc25_SBDB = 1060;    // sb pass-connects to idb (bi-directionally)
        public const NodeId dpc26_ACDB = 1331;    // acc to idb
        public const NodeId dpc27_SBADH = 140;    // sb pass-connects to adh (bi-directionally)
        public const NodeId dpc28_0ADH0 = 229;    // zero to adh0 bit0 only
        public const NodeId dpc29_0ADH17 = 203;   // zero to adh bits 7-1 only

        public const NodeId dpc30_ADHPCH = 48;    // load pch from adh
        public const NodeId dpc31_PCHPCH = 741;   // load pch from pch incremented
        public const NodeId dpc32_PCHADH = 1235;  // drive adh from pch incremented
        public const NodeId dpc33_PCHDB = 247;    // drive idb from pch incremented
        public const NodeId dpc34_PCLC = 1704;    // pch carry in and pcl FF detect?
        public const NodeId dpc35_PCHC = 1334;    // pch 0x?F detect - half-carry
        public const NodeId dpc36__hash_IPC = 379;   // pcl carry in (inverted)
        public const NodeId dpc36_tilde_IPC = 379;    // automatic alias replacing hash with tilde
        public const NodeId dpc37_PCLDB = 283;    // drive idb from pcl incremented
        public const NodeId dpc38_PCLADL = 438;   // drive adl from pcl incremented
        public const NodeId dpc39_PCLPCL = 898;   // load pcl from pcl incremented

        public const NodeId dpc40_ADLPCL = 414;   // load pcl from adl
        public const NodeId dpc41_DL_ADL = 1564;// pass-connect adl to mux node driven by idl
        public const NodeId dpc42_DL_ADH = 41;  // pass-connect adh to mux node driven by idl
        public const NodeId dpc43_DL_DB = 863;  // pass-connect idb to mux node driven by idl

        // Node buses

        public static readonly NodeBus<ushort> ab = new(
        [
            ab0,
            ab1,
            ab2,
            ab3,
            ab4,
            ab5,
            ab6,
            ab7,
            ab8,
            ab9,
            ab10,
            ab11,
            ab12,
            ab13,
            ab14,
            ab15,
        ]);

        public static readonly NodeBus<byte> db = new(
        [
            db0,
            db1,
            db2,
            db3,
            db4,
            db5,
            db6,
            db7,
        ]);

        public static readonly NodeBus<byte> a = new(
        [
            a0,
            a1,
            a2,
            a3,
            a4,
            a5,
            a6,
            a7,
        ]);

        public static readonly NodeBus<byte> x = new(
        [
            x0,
            x1,
            x2,
            x3,
            x4,
            x5,
            x6,
            x7,
        ]);

        public static readonly NodeBus<byte> y = new(
        [
            y0,
            y1,
            y2,
            y3,
            y4,
            y5,
            y6,
            y7,
        ]);

        public static readonly NodeBus<byte> pcl = new(
        [
            pcl0,
            pcl1,
            pcl2,
            pcl3,
            pcl4,
            pcl5,
            pcl6,
            pcl7,
        ]);

        public static readonly NodeBus<byte> pch = new(
        [
            pch0,
            pch1,
            pch2,
            pch3,
            pch4,
            pch5,
            pch6,
            pch7,
        ]);

        public static readonly NodeBus<byte> s = new(
        [
            s0,
            s1,
            s2,
            s3,
            s4,
            s5,
            s6,
            s7,
        ]);

        public static readonly NodeBus<byte> p = new(
        [
            p0,
            p1,
            p2,
            p3,
            p4,
            p5,
            p6,
            p7,
        ]);
    }
}
