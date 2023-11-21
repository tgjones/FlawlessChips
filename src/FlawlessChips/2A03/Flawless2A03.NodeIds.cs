namespace FlawlessChips;

partial class Flawless2A03
{
    public static class NodeIds
    {
        // power pins
        public const NodeId pwr = 10000;
        public const NodeId gnd = 10001;

        // other external pins
        public const NodeId res = 10004;
        public const NodeId rw = 10092;
        public const NodeId db0 = 11819;
        public const NodeId db1 = 11966;
        public const NodeId db2 = 12056;
        public const NodeId db3 = 12091;
        public const NodeId db4 = 12090;
        public const NodeId db5 = 12089;
        public const NodeId db6 = 12088;
        public const NodeId db7 = 12087;
        public const NodeId ab0 = 10020;
        public const NodeId ab1 = 10019;
        public const NodeId ab2 = 10030;
        public const NodeId ab3 = 10091;
        public const NodeId ab4 = 10335;
        public const NodeId ab5 = 10489;
        public const NodeId ab6 = 10727;
        public const NodeId ab7 = 11521;
        public const NodeId ab8 = 11628;
        public const NodeId ab9 = 11817;
        public const NodeId ab10 = 11965;
        public const NodeId ab11 = 12055;
        public const NodeId ab12 = 12084;
        public const NodeId ab13 = 12083;
        public const NodeId ab14 = 12085;
        public const NodeId ab15 = 12086;
        public const NodeId clk_in = 11669;
        public const NodeId phi2 = 10743;
        public const NodeId nmi = 10331;
        public const NodeId irq = 10488;
        public const NodeId dbg = 11214;
        public const NodeId out0 = 10007;
        public const NodeId out1 = 10008;
        public const NodeId out2 = 10005;
        public const NodeId joy1 = 10006;
        public const NodeId joy2 = 10029;
        public const NodeId snd1 = 10018;
        public const NodeId snd2 = 10017;

        // the current macros.js needs these
        public const NodeId rdy = 10758;
        public const NodeId so = 11246;
        public const NodeId sync = 11547;

        // clocks
        public const NodeId clk0 = 11235;
        public const NodeId clk1out = 10357;
        public const NodeId clk2out = 10843;

        // 6502 pins
        public const NodeId c_res = 159;       // pads: reset
        public const NodeId c_rw = 1156;       // pads: read not write
        public const NodeId c_db0 = 1005;      // pads: databus
        public const NodeId c_db1 = 82;
        public const NodeId c_db3 = 650;
        public const NodeId c_db2 = 945;
        public const NodeId c_db5 = 175;
        public const NodeId c_db4 = 1393;
        public const NodeId c_db7 = 1349;
        public const NodeId c_db6 = 1591;
        public const NodeId c_ab0 = 268;       // pads: address bus
        public const NodeId c_ab1 = 451;
        public const NodeId c_ab2 = 1340;
        public const NodeId c_ab3 = 211;
        public const NodeId c_ab4 = 435;
        public const NodeId c_ab5 = 736;
        public const NodeId c_ab6 = 887;
        public const NodeId c_ab7 = 1493;
        public const NodeId c_ab8 = 230;
        public const NodeId c_ab9 = 148;
        public const NodeId c_ab12 = 1237;
        public const NodeId c_ab13 = 349;
        public const NodeId c_ab10 = 1443;
        public const NodeId c_ab11 = 399;
        public const NodeId c_ab14 = 672;
        public const NodeId c_ab15 = 195;
        public const NodeId c_sync = 539;      // pads
        public const NodeId c_so = 1672;       // pads: set overflow
        public const NodeId c_clk0 = 1171;     // pads
        public const NodeId c_clk1out = 1163;  // pads
        public const NodeId c_clk2out = 421;   // pads
        public const NodeId c_rdy = 89;        // pads: ready
        public const NodeId c_nmi = 1297;      // pads: non maskable interrupt
        public const NodeId c_irq = 103;       // pads

        // 6502 internals
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
        public const NodeId p6 = 77;         // V bit of status register (storage node)
        public const NodeId p7 = 1370;       // N bit of status register (storage node)

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
        public const NodeId irline3 = 996;   // internal signal: PLA input - ir0 AND ir1
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
        public const NodeId cclk = 943;      // unbonded pad: internal non-overlappying phi2
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
        public const NodeId BRtaken = 1544;  // aka #TAKEN

        // internal signals and state: interrupt and vector related
        // segher says:
        //           public const NodeId P" are the latched external signals.
        //   "G" are the signals that actually trigger the interrupt.
        //   "NMIL" is to do the edge detection -- it's pretty much just a delayed NMIG.
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
        public const NodeId ADH_ABH = 821;      // load ABH latches from ADH bus

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
        public const NodeId dpc18__tilde_DAA = 1201;   // automatic alias replacing hash with tilde
        public const NodeId dpc19_ADDSB7 = 214;   // alu to sb bit 7 only

        public const NodeId dpc20_ADDSB06 = 129;  // alu to sb bits 6-0 only
        public const NodeId dpc21_ADDADL = 1015;  // alu to adl
        public const NodeId alurawcout = 808;     // alu raw carry out (no decimal adjust)
        public const NodeId notalucout = 412;     // alu carry out (inverted)
        public const NodeId alucout = 1146;       // alu carry out (latched by phi2)
        public const NodeId hash_alucout = 206;
        public const NodeId tilde_alucout = 206; // automatic alias replacing hash with tilde
        public const NodeId hash__hash_alucout = 465;
        public const NodeId tilde__tilde_alucout = 465; // automatic alias replacing hash with tilde
        public const NodeId notaluvout = 1308;    // alu overflow out
        public const NodeId aluvout = 938;        // alu overflow out (latched by phi2)

        public const NodeId hash_DBZ = 1268;   // internal signal: not (databus is zero)
        public const NodeId tilde_DBZ = 1268;    // automatic alias replacing hash with tilde
        public const NodeId DBZ = 744;       // internal signal: databus is zero
        public const NodeId DBNeg = 1200;    // internal signal: databus is negative (top bit of db) aka P-#DB7in

        public const NodeId dpc22__hash_DSA = 725;   // decimal related/SBC only (inverted)
        public const NodeId dpc22__tilde_DSA = 725;    // automatic alias replacing hash with tilde
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
        public const NodeId dpc35_PCHC = 1334;    // pcl 0x?F detect - half-carry
        public const NodeId dpc36__hash_IPC = 379;   // pcl carry in (inverted)
        public const NodeId dpc36__tilde_IPC = 379;    // automatic alias replacing hash with tilde
        public const NodeId dpc37_PCLDB = 283;    // drive idb from pcl incremented
        public const NodeId dpc38_PCLADL = 438;   // drive adl from pcl incremented
        public const NodeId dpc39_PCLPCL = 898;   // load pcl from pcl incremented

        public const NodeId dpc40_ADLPCL = 414;   // load pcl from adl
        public const NodeId dpc41_DL_ADL = 1564;// pass-connect adl to mux node driven by idl
        public const NodeId dpc42_DL_ADH = 41;  // pass-connect adh to mux node driven by idl
        public const NodeId dpc43_DL_DB = 863;  // pass-connect idb to mux node driven by idl

// internal signals connected to external pins
        public const NodeId _ab0 = 10056;
        public const NodeId _ab1 = 10055;
        public const NodeId _ab2 = 10088;
        public const NodeId _ab3 = 11249;
        public const NodeId _ab4 = 11255;
        public const NodeId _ab5 = 10719;
        public const NodeId _ab6 = 10822;
        public const NodeId _ab7 = 11497;
        public const NodeId _ab8 = 11600;
        public const NodeId _ab9 = 11776;
        public const NodeId _ab10 = 11886;
        public const NodeId _ab11 = 11908;
        public const NodeId _ab12 = 11935;
        public const NodeId _ab13 = 11967;
        public const NodeId _ab14 = 11992;
        public const NodeId _ab15 = 12015;
        public const NodeId _db7 = 10656;
        public const NodeId _db6 = 10616;
        public const NodeId _db5 = 10551;
        public const NodeId _db4 = 10490;
        public const NodeId _db3 = 10257;
        public const NodeId _db2 = 10671;
        public const NodeId _db1 = 10192;
        public const NodeId _db0 = 10146;
        public const NodeId _dbg = 11115;
        public const NodeId _res = 10057;
        public const NodeId _out0 = 10035;
        public const NodeId _out1 = 10037;
        public const NodeId _out2 = 10036;
        public const NodeId _rw = 10844;
        public const NodeId _nmi = 10458;
        public const NodeId _irq = 10701;

        // internal signals not directly connected to external pins
        public const NodeId __nmi = 11193;
        public const NodeId __irq = 13407;
        public const NodeId __rw = 10756;
        public const NodeId __ab15 = 12026;
        public const NodeId __ab14 = 12007;
        public const NodeId __ab13 = 11985;
        public const NodeId __ab12 = 11956;
        public const NodeId __ab11 = 11923;
        public const NodeId __ab10 = 11901;
        public const NodeId __ab9 = 11879;
        public const NodeId __ab8 = 11855;
        public const NodeId __ab7 = 11831;
        public const NodeId __ab6 = 11794;
        public const NodeId __ab5 = 11744;
        public const NodeId __ab4 = 11700;
        public const NodeId __ab3 = 11682;
        public const NodeId __ab2 = 11666;
        public const NodeId __ab1 = 11630;
        public const NodeId __ab0 = 11607;

        // internals
        public const NodeId rw_buf = 11133;
        public const NodeId dbe = 10938;
        public const NodeId dbg_en = 10946;
        public const NodeId ab_use_cpu = 11567;
        public const NodeId active_low_ab_use_pcm = 11411;
        public const NodeId ab_use_pcm = 11576;
        public const NodeId ab_use_spr_r = 11099;
        public const NodeId ab_use_spr_w = 10764;

        // $4000-$401F I/O
        public const NodeId apureg_rd = 11365;
        public const NodeId apureg__active_low_rd = 11166;
        public const NodeId apureg_wr = 11356;
        public const NodeId apureg__active_low_wr = 11265;

        public const NodeId active_low_r4018 = 10527;
        public const NodeId active_low_r401a = 10763;
        public const NodeId active_low_r4015 = 10749;
        public const NodeId w4002 = 10134;
        public const NodeId w4001 = 10559;
        public const NodeId w4005 = 10580;
        public const NodeId w4006 = 10133;
        public const NodeId w4008 = 13348;
        public const NodeId w400a = 13371;
        public const NodeId w400b = 13398;
        public const NodeId w400e = 13436;
        public const NodeId w4013 = 13457;
        public const NodeId w4012 = 13491;
        public const NodeId w4010 = 13514;
        public const NodeId w4014 = 13542;

        public const NodeId active_low_r4019 = 10759;
        public const NodeId w401a = 10773;
        public const NodeId w4003 = 13264;
        public const NodeId w4007 = 13273;
        public const NodeId w4004 = 13290;
        public const NodeId w400c = 13300;
        public const NodeId w4000 = 13322;
        public const NodeId w4015 = 13356;
        public const NodeId w4011 = 13375;
        public const NodeId w400f = 13415;
        public const NodeId active_low_r4017 = 13444;
        public const NodeId active_low_r4016 = 13474;
        public const NodeId w4016 = 10174;
        public const NodeId w4017 = 13520;


        // Square 0
        // $4002-$4003
        public const NodeId sq0_p0 = 10149;
        public const NodeId sq0_p1 = 10190;
        public const NodeId sq0_p2 = 10223;
        public const NodeId sq0_p3 = 10259;
        public const NodeId sq0_p4 = 10297;
        public const NodeId sq0_p5 = 10341;
        public const NodeId sq0_p6 = 10368;
        public const NodeId sq0_p7 = 10401;
        public const NodeId sq0_p8 = 10424;
        public const NodeId sq0_p9 = 10445;
        public const NodeId sq0_p10 = 10473;
        public const NodeId sq0__active_low_p0 = 10152;
        public const NodeId sq0__active_low_p1 = 10194;
        public const NodeId sq0__active_low_p2 = 10227;
        public const NodeId sq0__active_low_p3 = 10261;
        public const NodeId sq0__active_low_p4 = 10304;
        public const NodeId sq0__active_low_p5 = 10342;
        public const NodeId sq0__active_low_p6 = 10370;
        public const NodeId sq0__active_low_p7 = 10405;
        public const NodeId sq0__active_low_p8 = 10426;
        public const NodeId sq0__active_low_p9 = 10447;
        public const NodeId sq0__active_low_p10 = 10479;

// timer, duty cycle counter
        public const NodeId sq0_t0 = 12253;
        public const NodeId sq0_t1 = 12319;
        public const NodeId sq0_t2 = 12385;
        public const NodeId sq0_t3 = 12446;
        public const NodeId sq0_t4 = 12527;
        public const NodeId sq0_t5 = 12588;
        public const NodeId sq0_t6 = 12651;
        public const NodeId sq0_t7 = 12713;
        public const NodeId sq0_t8 = 12768;
        public const NodeId sq0_t9 = 12823;
        public const NodeId sq0_t10 = 12893;
        public const NodeId sq0__plus_t0 = 12259;
        public const NodeId sq0__plus_t1 = 12325;
        public const NodeId sq0__plus_t2 = 12392;
        public const NodeId sq0__plus_t3 = 12452;
        public const NodeId sq0__plus_t4 = 12532;
        public const NodeId sq0__plus_t5 = 12593;
        public const NodeId sq0__plus_t6 = 12658;
        public const NodeId sq0__plus_t7 = 12720;
        public const NodeId sq0__plus_t8 = 12775;
        public const NodeId sq0__plus_t9 = 12840;
        public const NodeId sq0__plus_t10 = 12898;
        public const NodeId sq0__active_low_t0 = 10135;
        public const NodeId sq0__active_low_t1 = 10178;
        public const NodeId sq0__active_low_t2 = 10215;
        public const NodeId sq0__active_low_t3 = 10249;
        public const NodeId sq0__active_low_t4 = 10283;
        public const NodeId sq0__active_low_t5 = 10328;
        public const NodeId sq0__active_low_t6 = 10361;
        public const NodeId sq0__active_low_t7 = 10396;
        public const NodeId sq0__active_low_t8 = 10418;
        public const NodeId sq0__active_low_t9 = 10439;
        public const NodeId sq0__active_low_t10 = 10466;

        public const NodeId sq0_c0 = 12930;
        public const NodeId sq0_c1 = 12980;
        public const NodeId sq0_c2 = 13031;
        public const NodeId sq0__plus_c0 = 10493;
        public const NodeId sq0__plus_c1 = 12985;
        public const NodeId sq0__plus_c2 = 12993;
        public const NodeId sq0__active_low_c0 = 10498;
        public const NodeId sq0__active_low_c1 = 10561;
        public const NodeId sq0__active_low_c2 = 10615;

// $4001
        public const NodeId sq0_swpb0 = 10497;
        public const NodeId sq0_swpb1 = 10504;
        public const NodeId sq0_swpb2 = 10506;
        public const NodeId sq0__active_low_swpb0 = 13029;
        public const NodeId sq0__active_low_swpb1 = 13071;
        public const NodeId sq0__active_low_swpb2 = 13139;

        public const NodeId sq0_swpdir = 10112;
        public const NodeId sq0__active_low_swpdir = 12978;

        public const NodeId sq0_swpp0 = 10686;
        public const NodeId sq0_swpp1 = 10647;
        public const NodeId sq0_swpp2 = 10608;
        public const NodeId sq0__active_low_swpp0 = 13140;
        public const NodeId sq0__active_low_swpp1 = 13068;
        public const NodeId sq0__active_low_swpp2 = 13027;

        public const NodeId sq0_swpen = 10546;
        public const NodeId sq0__active_low_swpen = 10514;

        public const NodeId sq0_swpt0 = 13115;
        public const NodeId sq0_swpt1 = 13057;
        public const NodeId sq0_swpt2 = 13018;
        public const NodeId sq0__plus_swpt0 = 13104;
        public const NodeId sq0__plus_swpt1 = 13052;
        public const NodeId sq0__plus_swpt2 = 13006;
        public const NodeId sq0__active_low_swpt0 = 10689;
        public const NodeId sq0__active_low_swpt1 = 10652;
        public const NodeId sq0__active_low_swpt2 = 10612;

// $4000
        public const NodeId sq0_envp0 = 10138;
        public const NodeId sq0_envp1 = 10184;
        public const NodeId sq0_envp2 = 10216;
        public const NodeId sq0_envp3 = 10251;
        public const NodeId sq0__active_low_envp0 = 12209;
        public const NodeId sq0__active_low_envp1 = 12282;
        public const NodeId sq0__active_low_envp2 = 12347;
        public const NodeId sq0__active_low_envp3 = 12415;

        public const NodeId sq0_envmode = 10294;
        public const NodeId sq0__active_low_envmode = 12541;

        public const NodeId sq0_lenhalt = 10338;
        public const NodeId sq0__active_low_lenhalt = 12601;

        public const NodeId sq0_duty0 = 10687;
        public const NodeId sq0_duty1 = 10643;
        public const NodeId sq0__active_low_duty0 = 13142;
        public const NodeId sq0__active_low_duty1 = 13074;

// envelope timer
        public const NodeId sq0_envt0 = 12249;
        public const NodeId sq0_envt1 = 12315;
        public const NodeId sq0_envt2 = 12381;
        public const NodeId sq0_envt3 = 12447;
        public const NodeId sq0__plus_envt0 = 12261;
        public const NodeId sq0__plus_envt1 = 12327;
        public const NodeId sq0__plus_envt2 = 12394;
        public const NodeId sq0__plus_envt3 = 12456;
        public const NodeId sq0__active_low_envt0 = 10139;
        public const NodeId sq0__active_low_envt1 = 10179;
        public const NodeId sq0__active_low_envt2 = 10217;
        public const NodeId sq0__active_low_envt3 = 10246;

// envelope counter (gets used for volume)
        public const NodeId sq0_envc0 = 12714;
        public const NodeId sq0_envc1 = 12766;
        public const NodeId sq0_envc2 = 12824;
        public const NodeId sq0_envc3 = 12894;
        public const NodeId sq0__plus_envc0 = 12685;
        public const NodeId sq0__plus_envc1 = 12665;
        public const NodeId sq0__plus_envc2 = 12647;
        public const NodeId sq0__plus_envc3 = 12639;
        public const NodeId sq0__active_low_envc0 = 10397;
        public const NodeId sq0__active_low_envc1 = 10419;
        public const NodeId sq0__active_low_envc2 = 10440;
        public const NodeId sq0__active_low_envc3 = 10467;

// length counter
        public const NodeId sq0_len0 = 15089;
        public const NodeId sq0_len1 = 15045;
        public const NodeId sq0_len2 = 14998;
        public const NodeId sq0_len3 = 14945;
        public const NodeId sq0_len4 = 14877;
        public const NodeId sq0_len5 = 14827;
        public const NodeId sq0_len6 = 14771;
        public const NodeId sq0_len7 = 14726;
        public const NodeId sq0__plus_len0 = 15088;
        public const NodeId sq0__plus_len1 = 15044;
        public const NodeId sq0__plus_len2 = 14997;
        public const NodeId sq0__plus_len3 = 14944;
        public const NodeId sq0__plus_len4 = 14876;
        public const NodeId sq0__plus_len5 = 14826;
        public const NodeId sq0__plus_len6 = 14770;
        public const NodeId sq0__plus_len7 = 14725;
        public const NodeId sq0__active_low_len0 = 12019;
        public const NodeId sq0__active_low_len1 = 11998;
        public const NodeId sq0__active_low_len2 = 11970;
        public const NodeId sq0__active_low_len3 = 11944;
        public const NodeId sq0__active_low_len4 = 11913;
        public const NodeId sq0__active_low_len5 = 11892;
        public const NodeId sq0__active_low_len6 = 11868;
        public const NodeId sq0__active_low_len7 = 11845;

// enabled (write $4015), active (read $4015)
        public const NodeId sq0_en = 14632;
        public const NodeId sq0__active_low_en = 14638;
        public const NodeId sq0_on = 11765;
        public const NodeId sq0__active_low_on = 14653;
        public const NodeId sq0_len_reload = 11748;
        public const NodeId sq0_silence = 10524;

        // actual output
        public const NodeId sq0_out0 = 10086;
        public const NodeId sq0_out1 = 10083;
        public const NodeId sq0_out2 = 10084;
        public const NodeId sq0_out3 = 10085;

        // Square 1
        // $4006-$4007
        public const NodeId sq1_p0 = 10148;
        public const NodeId sq1_p1 = 10191;
        public const NodeId sq1_p2 = 10221;
        public const NodeId sq1_p3 = 10256;
        public const NodeId sq1_p4 = 10295;
        public const NodeId sq1_p5 = 10339;
        public const NodeId sq1_p6 = 10364;
        public const NodeId sq1_p7 = 10402;
        public const NodeId sq1_p8 = 10423;
        public const NodeId sq1_p9 = 10444;
        public const NodeId sq1_p10 = 10474;
        public const NodeId sq1__active_low_p0 = 10153;
        public const NodeId sq1__active_low_p1 = 10193;
        public const NodeId sq1__active_low_p2 = 10228;
        public const NodeId sq1__active_low_p3 = 10260;
        public const NodeId sq1__active_low_p4 = 10303;
        public const NodeId sq1__active_low_p5 = 10343;
        public const NodeId sq1__active_low_p6 = 10371;
        public const NodeId sq1__active_low_p7 = 10404;
        public const NodeId sq1__active_low_p8 = 10425;
        public const NodeId sq1__active_low_p9 = 10446;
        public const NodeId sq1__active_low_p10 = 10477;

// timer, duty cycle counter
        public const NodeId sq1_t0 = 12250;
        public const NodeId sq1_t1 = 12316;
        public const NodeId sq1_t2 = 12382;
        public const NodeId sq1_t3 = 12445;
        public const NodeId sq1_t4 = 12524;
        public const NodeId sq1_t5 = 12585;
        public const NodeId sq1_t6 = 12648;
        public const NodeId sq1_t7 = 12712;
        public const NodeId sq1_t8 = 12767;
        public const NodeId sq1_t9 = 12820;
        public const NodeId sq1_t10 = 12890;
        public const NodeId sq1__plus_t0 = 12258;
        public const NodeId sq1__plus_t1 = 12324;
        public const NodeId sq1__plus_t2 = 12391;
        public const NodeId sq1__plus_t3 = 12451;
        public const NodeId sq1__plus_t4 = 12531;
        public const NodeId sq1__plus_t5 = 12592;
        public const NodeId sq1__plus_t6 = 12657;
        public const NodeId sq1__plus_t7 = 12719;
        public const NodeId sq1__plus_t8 = 12774;
        public const NodeId sq1__plus_t9 = 12839;
        public const NodeId sq1__plus_t10 = 12897;
        public const NodeId sq1__active_low_t0 = 10137;
        public const NodeId sq1__active_low_t1 = 10183;
        public const NodeId sq1__active_low_t2 = 10214;
        public const NodeId sq1__active_low_t3 = 10250;
        public const NodeId sq1__active_low_t4 = 10285;
        public const NodeId sq1__active_low_t5 = 10327;
        public const NodeId sq1__active_low_t6 = 10360;
        public const NodeId sq1__active_low_t7 = 10395;
        public const NodeId sq1__active_low_t8 = 10416;
        public const NodeId sq1__active_low_t9 = 10441;
        public const NodeId sq1__active_low_t10 = 10465;

        public const NodeId sq1_c0 = 12929;
        public const NodeId sq1_c1 = 12979;
        public const NodeId sq1_c2 = 13030;
        public const NodeId sq1__plus_c0 = 10492;
        public const NodeId sq1__plus_c1 = 12982;
        public const NodeId sq1__plus_c2 = 12992;
        public const NodeId sq1__active_low_c0 = 10495;
        public const NodeId sq1__active_low_c1 = 10558;
        public const NodeId sq1__active_low_c2 = 10610;

// $4005
        public const NodeId sq1_swpb0 = 10496;
        public const NodeId sq1_swpb1 = 10502;
        public const NodeId sq1_swpb2 = 10501;
        public const NodeId sq1__active_low_swpb0 = 13028;
        public const NodeId sq1__active_low_swpb1 = 13070;
        public const NodeId sq1__active_low_swpb2 = 13138;

        public const NodeId sq1_swpdir = 10127;
        public const NodeId sq1__active_low_swpdir = 12977;

        public const NodeId sq1_swpp0 = 10682;
        public const NodeId sq1_swpp1 = 10649;
        public const NodeId sq1_swpp2 = 10607;
        public const NodeId sq1__active_low_swpp0 = 13137;
        public const NodeId sq1__active_low_swpp1 = 13067;
        public const NodeId sq1__active_low_swpp2 = 13026;

        public const NodeId sq1_swpen = 10545;
        public const NodeId sq1__active_low_swpen = 10513;

        public const NodeId sq1_swpt0 = 13114;
        public const NodeId sq1_swpt1 = 13056;
        public const NodeId sq1_swpt2 = 13017;
        public const NodeId sq1__plus_swpt0 = 13103;
        public const NodeId sq1__plus_swpt1 = 13051;
        public const NodeId sq1__plus_swpt2 = 13005;
        public const NodeId sq1__active_low_swpt0 = 10684;
        public const NodeId sq1__active_low_swpt1 = 10648;
        public const NodeId sq1__active_low_swpt2 = 10603;

// $4004
        public const NodeId sq1_envp0 = 10136;
        public const NodeId sq1_envp1 = 10182;
        public const NodeId sq1_envp2 = 10213;
        public const NodeId sq1_envp3 = 10248;
        public const NodeId sq1__active_low_envp0 = 12208;
        public const NodeId sq1__active_low_envp1 = 12279;
        public const NodeId sq1__active_low_envp2 = 12344;
        public const NodeId sq1__active_low_envp3 = 12412;

        public const NodeId sq1_envmode = 10292;
        public const NodeId sq1__active_low_envmode = 12538;

        public const NodeId sq1_lenhalt = 10337;
        public const NodeId sq1__active_low_lenhalt = 12600;

        public const NodeId sq1_duty0 = 10683;
        public const NodeId sq1_duty1 = 10644;
        public const NodeId sq1__active_low_duty0 = 13141;
        public const NodeId sq1__active_low_duty1 = 13073;

// envelope timer
        public const NodeId sq1_envt0 = 12248;
        public const NodeId sq1_envt1 = 12314;
        public const NodeId sq1_envt2 = 12380;
        public const NodeId sq1_envt3 = 12444;
        public const NodeId sq1__plus_envt0 = 12256;
        public const NodeId sq1__plus_envt1 = 12322;
        public const NodeId sq1__plus_envt2 = 12389;
        public const NodeId sq1__plus_envt3 = 12455;
        public const NodeId sq1__active_low_envt0 = 10140;
        public const NodeId sq1__active_low_envt1 = 10181;
        public const NodeId sq1__active_low_envt2 = 10212;
        public const NodeId sq1__active_low_envt3 = 10247;

// envelope counter (gets used for volume)
        public const NodeId sq1_envc0 = 12711;
        public const NodeId sq1_envc1 = 12763;
        public const NodeId sq1_envc2 = 12819;
        public const NodeId sq1_envc3 = 12889;
        public const NodeId sq1__plus_envc0 = 12684;
        public const NodeId sq1__plus_envc1 = 12664;
        public const NodeId sq1__plus_envc2 = 12646;
        public const NodeId sq1__plus_envc3 = 12638;
        public const NodeId sq1__active_low_envc0 = 10394;
        public const NodeId sq1__active_low_envc1 = 10414;
        public const NodeId sq1__active_low_envc2 = 10438;
        public const NodeId sq1__active_low_envc3 = 10468;

// length counter
        public const NodeId sq1_len0 = 15086;
        public const NodeId sq1_len1 = 15042;
        public const NodeId sq1_len2 = 14995;
        public const NodeId sq1_len3 = 14942;
        public const NodeId sq1_len4 = 14874;
        public const NodeId sq1_len5 = 14824;
        public const NodeId sq1_len6 = 14768;
        public const NodeId sq1_len7 = 14723;
        public const NodeId sq1__plus_len0 = 15087;
        public const NodeId sq1__plus_len1 = 15043;
        public const NodeId sq1__plus_len2 = 14996;
        public const NodeId sq1__plus_len3 = 14943;
        public const NodeId sq1__plus_len4 = 14875;
        public const NodeId sq1__plus_len5 = 14825;
        public const NodeId sq1__plus_len6 = 14769;
        public const NodeId sq1__plus_len7 = 14724;
        public const NodeId sq1__active_low_len0 = 12017;
        public const NodeId sq1__active_low_len1 = 11996;
        public const NodeId sq1__active_low_len2 = 11973;
        public const NodeId sq1__active_low_len3 = 11943;
        public const NodeId sq1__active_low_len4 = 11912;
        public const NodeId sq1__active_low_len5 = 11888;
        public const NodeId sq1__active_low_len6 = 11867;
        public const NodeId sq1__active_low_len7 = 11844;

// enabled (write $4015), active (read $4015)
        public const NodeId sq1_en = 14631;
        public const NodeId sq1__active_low_en = 14637;
        public const NodeId sq1_on = 11768;
        public const NodeId sq1__active_low_on = 14652;
        public const NodeId sq1_len_reload = 11752;
        public const NodeId sq1_silence = 10522;

        // actual output
        public const NodeId sq1_out0 = 10082;
        public const NodeId sq1_out1 = 10081;
        public const NodeId sq1_out2 = 10080;
        public const NodeId sq1_out3 = 10079;

        // Triangle
        // $4008
        public const NodeId tri_lin0 = 10952;
        public const NodeId tri_lin1 = 10991;
        public const NodeId tri_lin2 = 11105;
        public const NodeId tri_lin3 = 11140;
        public const NodeId tri_lin4 = 11185;
        public const NodeId tri_lin5 = 11220;
        public const NodeId tri_lin6 = 11262;
        public const NodeId tri__active_low_lin0 = 13232;
        public const NodeId tri__active_low_lin1 = 13271;
        public const NodeId tri__active_low_lin2 = 13306;
        public const NodeId tri__active_low_lin3 = 13376;
        public const NodeId tri__active_low_lin4 = 13452;
        public const NodeId tri__active_low_lin5 = 13521;
        public const NodeId tri__active_low_lin6 = 13584;
        public const NodeId tri_lin_en = 11304;
        public const NodeId tri__active_low_lin_en = 13653;

// linear counter
        public const NodeId tri_lc0 = 13257;
        public const NodeId tri_lc1 = 13287;
        public const NodeId tri_lc2 = 13336;
        public const NodeId tri_lc3 = 13408;
        public const NodeId tri_lc4 = 13481;
        public const NodeId tri_lc5 = 13551;
        public const NodeId tri_lc6 = 13615;
        public const NodeId tri__plus_lc0 = 13260;
        public const NodeId tri__plus_lc1 = 13293;
        public const NodeId tri__plus_lc2 = 13346;
        public const NodeId tri__plus_lc3 = 13418;
        public const NodeId tri__plus_lc4 = 13489;
        public const NodeId tri__plus_lc5 = 13559;
        public const NodeId tri__plus_lc6 = 13624;
        public const NodeId tri__active_low_lc0 = 10951;
        public const NodeId tri__active_low_lc1 = 10990;
        public const NodeId tri__active_low_lc2 = 11104;
        public const NodeId tri__active_low_lc3 = 11137;
        public const NodeId tri__active_low_lc4 = 11187;
        public const NodeId tri__active_low_lc5 = 11218;
        public const NodeId tri__active_low_lc6 = 11261;

// period ($400A/$400B)
        public const NodeId tri_p0 = 11420;
        public const NodeId tri_p1 = 11400;
        public const NodeId tri_p2 = 11377;
        public const NodeId tri_p3 = 11357;
        public const NodeId tri_p4 = 11334;
        public const NodeId tri_p5 = 11305;
        public const NodeId tri_p6 = 11272;
        public const NodeId tri_p7 = 11224;
        public const NodeId tri_p8 = 11190;
        public const NodeId tri_p9 = 11144;
        public const NodeId tri_p10 = 11112;
        public const NodeId tri__active_low_p0 = 13960;
        public const NodeId tri__active_low_p1 = 13905;
        public const NodeId tri__active_low_p2 = 13856;
        public const NodeId tri__active_low_p3 = 13803;
        public const NodeId tri__active_low_p4 = 13742;
        public const NodeId tri__active_low_p5 = 13684;
        public const NodeId tri__active_low_p6 = 13628;
        public const NodeId tri__active_low_p7 = 13562;
        public const NodeId tri__active_low_p8 = 13494;
        public const NodeId tri__active_low_p9 = 13422;
        public const NodeId tri__active_low_p10 = 13352;

// timer
        public const NodeId tri_t0 = 13938;
        public const NodeId tri_t1 = 13887;
        public const NodeId tri_t2 = 13834;
        public const NodeId tri_t3 = 13778;
        public const NodeId tri_t4 = 13720;
        public const NodeId tri_t5 = 13663;
        public const NodeId tri_t6 = 13602;
        public const NodeId tri_t7 = 13539;
        public const NodeId tri_t8 = 13471;
        public const NodeId tri_t9 = 13395;
        public const NodeId tri_t10 = 13325;
        public const NodeId tri__plus_t0 = 13937;
        public const NodeId tri__plus_t1 = 13886;
        public const NodeId tri__plus_t2 = 13833;
        public const NodeId tri__plus_t3 = 13777;
        public const NodeId tri__plus_t4 = 13719;
        public const NodeId tri__plus_t5 = 13662;
        public const NodeId tri__plus_t6 = 13601;
        public const NodeId tri__plus_t7 = 13538;
        public const NodeId tri__plus_t8 = 13470;
        public const NodeId tri__plus_t9 = 13394;
        public const NodeId tri__plus_t10 = 13324;
        public const NodeId tri__active_low_t0 = 11425;
        public const NodeId tri__active_low_t1 = 11405;
        public const NodeId tri__active_low_t2 = 11380;
        public const NodeId tri__active_low_t3 = 11360;
        public const NodeId tri__active_low_t4 = 11338;
        public const NodeId tri__active_low_t5 = 11310;
        public const NodeId tri__active_low_t6 = 11281;
        public const NodeId tri__active_low_t7 = 11228;
        public const NodeId tri__active_low_t8 = 11192;
        public const NodeId tri__active_low_t9 = 11156;
        public const NodeId tri__active_low_t10 = 11116;

        public const NodeId tri_c0 = 13929;
        public const NodeId tri_c1 = 13876;
        public const NodeId tri_c2 = 13821;
        public const NodeId tri_c3 = 13761;
        public const NodeId tri_c4 = 13703;
        public const NodeId tri__plus_c0 = 11413;
        public const NodeId tri__plus_c1 = 11394;
        public const NodeId tri__plus_c2 = 11372;
        public const NodeId tri__plus_c3 = 11349;
        public const NodeId tri__plus_c4 = 11325;
        public const NodeId tri__active_low_c0 = 11418;
        public const NodeId tri__active_low_c1 = 11397;
        public const NodeId tri__active_low_c2 = 11375;
        public const NodeId tri__active_low_c3 = 11355;
        public const NodeId tri__active_low_c4 = 11329;

// length counter
        public const NodeId tri_len0 = 15085;
        public const NodeId tri_len1 = 15041;
        public const NodeId tri_len2 = 14994;
        public const NodeId tri_len3 = 14941;
        public const NodeId tri_len4 = 14873;
        public const NodeId tri_len5 = 14823;
        public const NodeId tri_len6 = 14767;
        public const NodeId tri_len7 = 14722;
        public const NodeId tri__plus_len0 = 15084;
        public const NodeId tri__plus_len1 = 15040;
        public const NodeId tri__plus_len2 = 14993;
        public const NodeId tri__plus_len3 = 14940;
        public const NodeId tri__plus_len4 = 14872;
        public const NodeId tri__plus_len5 = 14822;
        public const NodeId tri__plus_len6 = 14766;
        public const NodeId tri__plus_len7 = 14721;
        public const NodeId tri__active_low_len0 = 12020;
        public const NodeId tri__active_low_len1 = 11997;
        public const NodeId tri__active_low_len2 = 11972;
        public const NodeId tri__active_low_len3 = 11940;
        public const NodeId tri__active_low_len4 = 11911;
        public const NodeId tri__active_low_len5 = 11891;
        public const NodeId tri__active_low_len6 = 11869;
        public const NodeId tri__active_low_len7 = 11843;

// enabled (write $4015), active (read $4015)
        public const NodeId tri_en = 14630;
        public const NodeId tri__active_low_en = 14636;
        public const NodeId tri_on = 11767;
        public const NodeId tri__active_low_on = 14651;
        public const NodeId tri_len_reload = 11750;
        public const NodeId tri_silence = 11346;

        // output bits
        public const NodeId tri_out0 = 13941;
        public const NodeId tri_out1 = 13890;
        public const NodeId tri_out2 = 13832;
        public const NodeId tri_out3 = 13776;

        // Noise
        // $400E
        public const NodeId noi_freq0 = 11597;
        public const NodeId noi_freq1 = 11678;
        public const NodeId noi_freq2 = 11625;
        public const NodeId noi_freq3 = 11663;
        public const NodeId noi__active_low_freq0 = 14373;
        public const NodeId noi__active_low_freq1 = 14533;
        public const NodeId noi__active_low_freq2 = 14429;
        public const NodeId noi__active_low_freq3 = 14487;

        public const NodeId noi_lfsrmode = 11419;
        public const NodeId noi__active_low_lfsrmode = 13931;

// Timer LFSR - triggers on 10000000000
        public const NodeId noi_t0 = 14156;
        public const NodeId noi_t1 = 14179;
        public const NodeId noi_t2 = 14206;
        public const NodeId noi_t3 = 14234;
        public const NodeId noi_t4 = 14256;
        public const NodeId noi_t5 = 14285;
        public const NodeId noi_t6 = 14309;
        public const NodeId noi_t7 = 14371;
        public const NodeId noi_t8 = 11523;
        public const NodeId noi_t9 = 14449;
        public const NodeId noi_t10 = 11519;
        public const NodeId noi__active_low_t0 = 14153;
        public const NodeId noi__active_low_t1 = 14173;
        public const NodeId noi__active_low_t2 = 14202;
        public const NodeId noi__active_low_t3 = 14228;
        public const NodeId noi__active_low_t4 = 14253;
        public const NodeId noi__active_low_t5 = 14280;
        public const NodeId noi__active_low_t6 = 14305;
        public const NodeId noi__active_low_t7 = 14365;
        public const NodeId noi__active_low_t8 = 14406;
        public const NodeId noi__active_low_t9 = 14439;
        public const NodeId noi__active_low_t10 = 14478;

// Duty cycle LFSR
        public const NodeId noi_c0 = 14066;
        public const NodeId noi_c1 = 14105;
        public const NodeId noi_c2 = 14127;
        public const NodeId noi_c3 = 14146;
        public const NodeId noi_c4 = 14168;
        public const NodeId noi_c5 = 14198;
        public const NodeId noi_c6 = 14223;
        public const NodeId noi_c7 = 14249;
        public const NodeId noi_c8 = 14277;
        public const NodeId noi_c9 = 14299;
        public const NodeId noi_c10 = 14361;
        public const NodeId noi_c11 = 14400;
        public const NodeId noi_c12 = 14435;
        public const NodeId noi_c13 = 14472;
        public const NodeId noi_c14 = 14507;
        public const NodeId noi__plus_c0 = 14077;
        public const NodeId noi__plus_c1 = 14116;
        public const NodeId noi__plus_c2 = 14138;
        public const NodeId noi__plus_c3 = 14158;
        public const NodeId noi__plus_c4 = 14182;
        public const NodeId noi__plus_c5 = 14213;
        public const NodeId noi__plus_c6 = 14236;
        public const NodeId noi__plus_c7 = 14258;
        public const NodeId noi__plus_c8 = 14286;
        public const NodeId noi__plus_c9 = 14311;
        public const NodeId noi__plus_c10 = 14372;
        public const NodeId noi__plus_c11 = 14415;
        public const NodeId noi__plus_c12 = 14454;
        public const NodeId noi__plus_c13 = 14483;
        public const NodeId noi__plus_c14 = 11477;
        public const NodeId noi__active_low_c0 = 14073;
        public const NodeId noi__active_low_c1 = 14115;
        public const NodeId noi__active_low_c2 = 14131;
        public const NodeId noi__active_low_c3 = 14155;
        public const NodeId noi__active_low_c4 = 14176;
        public const NodeId noi__active_low_c5 = 14205;
        public const NodeId noi__active_low_c6 = 14231;
        public const NodeId noi__active_low_c7 = 14255;
        public const NodeId noi__active_low_c8 = 14284;
        public const NodeId noi__active_low_c9 = 14308;
        public const NodeId noi__active_low_c10 = 14369;
        public const NodeId noi__active_low_c11 = 14410;
        public const NodeId noi__active_low_c12 = 14448;
        public const NodeId noi__active_low_c13 = 14479;
        public const NodeId noi__active_low_c14 = 14518;

// $400C
        public const NodeId noi_envp0 = 11450;
        public const NodeId noi_envp1 = 11479;
        public const NodeId noi_envp2 = 11494;
        public const NodeId noi_envp3 = 11517;
        public const NodeId noi__active_low_envp0 = 14007;
        public const NodeId noi__active_low_envp1 = 14050;
        public const NodeId noi__active_low_envp2 = 14084;
        public const NodeId noi__active_low_envp3 = 14132;

        public const NodeId noi_envmode = 11536;
        public const NodeId noi__active_low_envmode = 14165;

        public const NodeId noi_lenhalt = 11553;
        public const NodeId noi__active_low_lenhalt = 14209;

// envelope timer
        public const NodeId noi_envt0 = 14027;
        public const NodeId noi_envt1 = 14069;
        public const NodeId noi_envt2 = 14124;
        public const NodeId noi_envt3 = 14154;
        public const NodeId noi__plus_envt0 = 14025;
        public const NodeId noi__plus_envt1 = 14064;
        public const NodeId noi__plus_envt2 = 14121;
        public const NodeId noi__plus_envt3 = 14149;
        public const NodeId noi__active_low_envt0 = 11449;
        public const NodeId noi__active_low_envt1 = 11478;
        public const NodeId noi__active_low_envt2 = 11493;
        public const NodeId noi__active_low_envt3 = 11516;

// envelope counter (gets used for volume)
        public const NodeId noi_envc0 = 14521;
        public const NodeId noi_envc1 = 14469;
        public const NodeId noi_envc2 = 14414;
        public const NodeId noi_envc3 = 14354;
        public const NodeId noi__plus_envc0 = 14519;
        public const NodeId noi__plus_envc1 = 14467;
        public const NodeId noi__plus_envc2 = 14412;
        public const NodeId noi__plus_envc3 = 14353;
        public const NodeId noi__active_low_envc0 = 11680;
        public const NodeId noi__active_low_envc1 = 11664;
        public const NodeId noi__active_low_envc2 = 11629;
        public const NodeId noi__active_low_envc3 = 11602;

// length counter
        public const NodeId noi_len0 = 15082;
        public const NodeId noi_len1 = 15038;
        public const NodeId noi_len2 = 14991;
        public const NodeId noi_len3 = 14938;
        public const NodeId noi_len4 = 14870;
        public const NodeId noi_len5 = 14820;
        public const NodeId noi_len6 = 14764;
        public const NodeId noi_len7 = 14719;
        public const NodeId noi__plus_len0 = 15083;
        public const NodeId noi__plus_len1 = 15039;
        public const NodeId noi__plus_len2 = 14992;
        public const NodeId noi__plus_len3 = 14939;
        public const NodeId noi__plus_len4 = 14871;
        public const NodeId noi__plus_len5 = 14821;
        public const NodeId noi__plus_len6 = 14765;
        public const NodeId noi__plus_len7 = 14720;
        public const NodeId noi__active_low_len0 = 12018;
        public const NodeId noi__active_low_len1 = 11995;
        public const NodeId noi__active_low_len2 = 11972;
        public const NodeId noi__active_low_len3 = 11942;
        public const NodeId noi__active_low_len4 = 11910;
        public const NodeId noi__active_low_len5 = 11890;
        public const NodeId noi__active_low_len6 = 11866;
        public const NodeId noi__active_low_len7 = 11842;

// enabled (write $4015), active (read $4015)
        public const NodeId noi_en = 14629;
        public const NodeId noi__active_low_en = 14635;
        public const NodeId noi_on = 11766;
        public const NodeId noi__active_low_on = 14650;
        public const NodeId noi_len_reload = 11747;
        public const NodeId noi_silence = 11696;

        // actual output
        public const NodeId noi_out0 = 14538;
        public const NodeId noi_out1 = 14489;
        public const NodeId noi_out2 = 14434;
        public const NodeId noi_out3 = 11401;

        // DPCM

        // bit counter
        public const NodeId pcm_bits0 = 14204;
        public const NodeId pcm_bits1 = 14243;
        public const NodeId pcm_bits2 = 14283;
        public const NodeId pcm__plus_bits0 = 14211;
        public const NodeId pcm__plus_bits1 = 14246;
        public const NodeId pcm__plus_bits2 = 14287;
        public const NodeId pcm__active_low_bits0 = 11546;
        public const NodeId pcm__active_low_bits1 = 11561;
        public const NodeId pcm__active_low_bits2 = 11571;
        public const NodeId pcm_bits_overflow = 11540;

        // next sample buffer
        public const NodeId pcm_buf0 = 11106;
        public const NodeId pcm_buf1 = 11138;
        public const NodeId pcm_buf2 = 11186;
        public const NodeId pcm_buf3 = 11219;
        public const NodeId pcm_buf4 = 11264;
        public const NodeId pcm_buf5 = 11301;
        public const NodeId pcm_buf6 = 11330;
        public const NodeId pcm_buf7 = 11352;
        public const NodeId pcm__active_low_buf0 = 13308;
        public const NodeId pcm__active_low_buf1 = 13378;
        public const NodeId pcm__active_low_buf2 = 13451;
        public const NodeId pcm__active_low_buf3 = 13518;
        public const NodeId pcm__active_low_buf4 = 13586;
        public const NodeId pcm__active_low_buf5 = 13651;
        public const NodeId pcm__active_low_buf6 = 13705;
        public const NodeId pcm__active_low_buf7 = 13765;
        public const NodeId pcm_loadbuf = 11094;

        // sample shift register
        public const NodeId pcm_sr0 = 11060;
        public const NodeId pcm_sr1 = 11131;
        public const NodeId pcm_sr2 = 11178;
        public const NodeId pcm_sr3 = 11213;
        public const NodeId pcm_sr4 = 11248;
        public const NodeId pcm_sr5 = 11296;
        public const NodeId pcm_sr6 = 11323;
        public const NodeId pcm_sr7 = 11347;
        public const NodeId pcm__active_low_sr0 = 11101;
        public const NodeId pcm__active_low_sr1 = 13384;
        public const NodeId pcm__active_low_sr2 = 13456;
        public const NodeId pcm__active_low_sr3 = 13525;
        public const NodeId pcm__active_low_sr4 = 13590;
        public const NodeId pcm__active_low_sr5 = 13655;
        public const NodeId pcm__active_low_sr6 = 13709;
        public const NodeId pcm__active_low_sr7 = 13767;
        public const NodeId pcm_plus_active_low_sr0 = 13344;
        public const NodeId pcm_plus_active_low_sr1 = 13405;
        public const NodeId pcm_plus_active_low_sr2 = 13480;
        public const NodeId pcm_plus_active_low_sr3 = 13549;
        public const NodeId pcm_plus_active_low_sr4 = 13614;
        public const NodeId pcm_plus_active_low_sr5 = 13672;
        public const NodeId pcm_plus_active_low_sr6 = 13729;
        public const NodeId pcm_plus_active_low_sr7 = 13787;
        public const NodeId pcm_loadsr = 11093;
        public const NodeId pcm_shiftsr = 11102;

        // $4010
        public const NodeId pcm_freq0 = 11707;
        public const NodeId pcm_freq1 = 11688;
        public const NodeId pcm_freq2 = 11670;
        public const NodeId pcm_freq3 = 11635;
        public const NodeId pcm__active_low_freq0 = 14576;
        public const NodeId pcm__active_low_freq1 = 14535;
        public const NodeId pcm__active_low_freq2 = 14486;
        public const NodeId pcm__active_low_freq3 = 14431;

        public const NodeId pcm_loop = 11510;
        public const NodeId pcm__active_low_loop = 14375;

        public const NodeId pcm_irqen = 11584;
        public const NodeId pcm__active_low_irqen = 14296;

// Timer LFSR - triggers on 100000000
        public const NodeId pcm_t0 = 14457;
        public const NodeId pcm_t1 = 14419;
        public const NodeId pcm_t2 = 14379;
        public const NodeId pcm_t3 = 14332;
        public const NodeId pcm_t4 = 11579;
        public const NodeId pcm_t5 = 14262;
        public const NodeId pcm_t6 = 14239;
        public const NodeId pcm_t7 = 14215;
        public const NodeId pcm_t8 = 11544;
        public const NodeId pcm__plus_t0 = 14470;
        public const NodeId pcm__plus_t1 = 14432;
        public const NodeId pcm__plus_t2 = 14399;
        public const NodeId pcm__plus_t3 = 14359;
        public const NodeId pcm__plus_t4 = 14298;
        public const NodeId pcm__plus_t5 = 14276;
        public const NodeId pcm__plus_t6 = 14248;
        public const NodeId pcm__plus_t7 = 14222;
        public const NodeId pcm__plus_t8 = 14200;
        public const NodeId pcm__active_low_t0 = 14476;
        public const NodeId pcm__active_low_t1 = 14443;
        public const NodeId pcm__active_low_t2 = 14408;
        public const NodeId pcm__active_low_t3 = 14366;
        public const NodeId pcm__active_low_t4 = 14306;
        public const NodeId pcm__active_low_t5 = 14281;
        public const NodeId pcm__active_low_t6 = 14254;
        public const NodeId pcm__active_low_t7 = 14229;
        public const NodeId pcm__active_low_t8 = 14203;
        public const NodeId pcm_load_t = 11508;
        public const NodeId pcm_shift_t = 11537;
        public const NodeId pcm_t_xor_in = 14502;

        // $4012 - start address
        public const NodeId pcm_sa0 = 11764;
        public const NodeId pcm_sa1 = 11807;
        public const NodeId pcm_sa2 = 11838;
        public const NodeId pcm_sa3 = 11859;
        public const NodeId pcm_sa4 = 11883;
        public const NodeId pcm_sa5 = 11907;
        public const NodeId pcm_sa6 = 11927;
        public const NodeId pcm_sa7 = 11961;
        public const NodeId pcm__active_low_sa0 = 14599;
        public const NodeId pcm__active_low_sa1 = 14668;
        public const NodeId pcm__active_low_sa2 = 14708;
        public const NodeId pcm__active_low_sa3 = 14757;
        public const NodeId pcm__active_low_sa4 = 14810;
        public const NodeId pcm__active_low_sa5 = 14860;
        public const NodeId pcm__active_low_sa6 = 14914;
        public const NodeId pcm__active_low_sa7 = 14982;

// current address
        public const NodeId pcm_a0 = 14326;
        public const NodeId pcm_a1 = 14402;
        public const NodeId pcm_a2 = 14459;
        public const NodeId pcm_a3 = 14511;
        public const NodeId pcm_a4 = 14559;
        public const NodeId pcm_a5 = 14589;
        public const NodeId pcm_a6 = 14642;
        public const NodeId pcm_a7 = 14695;
        public const NodeId pcm_a8 = 14733;
        public const NodeId pcm_a9 = 14785;
        public const NodeId pcm_a10 = 14837;
        public const NodeId pcm_a11 = 14886;
        public const NodeId pcm_a12 = 14956;
        public const NodeId pcm_a13 = 15008;
        public const NodeId pcm_a14 = 15054;
        public const NodeId pcm__plus_a0 = 11595;
        public const NodeId pcm__plus_a1 = 11623;
        public const NodeId pcm__plus_a2 = 11645;
        public const NodeId pcm__plus_a3 = 11676;
        public const NodeId pcm__plus_a4 = 11694;
        public const NodeId pcm__plus_a5 = 11725;
        public const NodeId pcm__plus_a6 = 11783;
        public const NodeId pcm__plus_a7 = 11818;
        public const NodeId pcm__plus_a8 = 11847;
        public const NodeId pcm__plus_a9 = 11871;
        public const NodeId pcm__plus_a10 = 11894;
        public const NodeId pcm__plus_a11 = 11916;
        public const NodeId pcm__plus_a12 = 11949;
        public const NodeId pcm__plus_a13 = 11976;
        public const NodeId pcm__plus_a14 = 12000;
        public const NodeId pcm__active_low_a0 = 11586;
        public const NodeId pcm__active_low_a1 = 11613;
        public const NodeId pcm__active_low_a2 = 11636;
        public const NodeId pcm__active_low_a3 = 11667;
        public const NodeId pcm__active_low_a4 = 11686;
        public const NodeId pcm__active_low_a5 = 11708;
        public const NodeId pcm__active_low_a6 = 11763;
        public const NodeId pcm__active_low_a7 = 11808;
        public const NodeId pcm__active_low_a8 = 11836;
        public const NodeId pcm__active_low_a9 = 11860;
        public const NodeId pcm__active_low_a10 = 11882;
        public const NodeId pcm__active_low_a11 = 11905;
        public const NodeId pcm__active_low_a12 = 11928;
        public const NodeId pcm__active_low_a13 = 11963;
        public const NodeId pcm__active_low_a14 = 11988;
        public const NodeId pcm_init_addr_and_ctr = 11092;
        public const NodeId pcm_inc_addr_dec_ctr = 11097;

        // $4013 - sample length
        public const NodeId pcm_l0 = 11358;
        public const NodeId pcm_l1 = 11335;
        public const NodeId pcm_l2 = 11306;
        public const NodeId pcm_l3 = 11273;
        public const NodeId pcm_l4 = 11223;
        public const NodeId pcm_l5 = 11191;
        public const NodeId pcm_l6 = 11142;
        public const NodeId pcm_l7 = 11113;
        public const NodeId pcm__active_low_l0 = 13804;
        public const NodeId pcm__active_low_l1 = 13743;
        public const NodeId pcm__active_low_l2 = 13685;
        public const NodeId pcm__active_low_l3 = 13629;
        public const NodeId pcm__active_low_l4 = 13563;
        public const NodeId pcm__active_low_l5 = 13495;
        public const NodeId pcm__active_low_l6 = 13423;
        public const NodeId pcm__active_low_l7 = 13353;

// length counter
        public const NodeId pcm_lc0 = 13992;
        public const NodeId pcm_lc1 = 13940;
        public const NodeId pcm_lc2 = 13889;
        public const NodeId pcm_lc3 = 13836;
        public const NodeId pcm_lc4 = 13780;
        public const NodeId pcm_lc5 = 13722;
        public const NodeId pcm_lc6 = 13665;
        public const NodeId pcm_lc7 = 13604;
        public const NodeId pcm_lc8 = 13541;
        public const NodeId pcm_lc9 = 13473;
        public const NodeId pcm_lc10 = 13397;
        public const NodeId pcm_lc11 = 13327;
        public const NodeId pcm__plus_lc0 = 13991;
        public const NodeId pcm__plus_lc1 = 13939;
        public const NodeId pcm__plus_lc2 = 13888;
        public const NodeId pcm__plus_lc3 = 13835;
        public const NodeId pcm__plus_lc4 = 13779;
        public const NodeId pcm__plus_lc5 = 13721;
        public const NodeId pcm__plus_lc6 = 13664;
        public const NodeId pcm__plus_lc7 = 13603;
        public const NodeId pcm__plus_lc8 = 13540;
        public const NodeId pcm__plus_lc9 = 13472;
        public const NodeId pcm__plus_lc10 = 13396;
        public const NodeId pcm__plus_lc11 = 13326;
        public const NodeId pcm__active_low_lc0 = 11441;
        public const NodeId pcm__active_low_lc1 = 11424;
        public const NodeId pcm__active_low_lc2 = 11404;
        public const NodeId pcm__active_low_lc3 = 11381;
        public const NodeId pcm__active_low_lc4 = 11361;
        public const NodeId pcm__active_low_lc5 = 11337;
        public const NodeId pcm__active_low_lc6 = 11311;
        public const NodeId pcm__active_low_lc7 = 11282;
        public const NodeId pcm__active_low_lc8 = 11226;
        public const NodeId pcm__active_low_lc9 = 11195;
        public const NodeId pcm__active_low_lc10 = 11152;
        public const NodeId pcm__active_low_lc11 = 11119;
        public const NodeId pcm_lc__active_low_underflow = 11096;
        public const NodeId pcm_lc_plus_active_low_underflow = 11463;

// enabled (write $4015), active (read $4015)
// these are actually the same register
        public const NodeId pcm_en = 11481;
        public const NodeId pcm__plus_en = 14060;
        public const NodeId pcm__active_low_en = 14068;
        public const NodeId pcm_on = 11481;
        public const NodeId pcm_rd_active = 14089;
        public const NodeId pcm__active_low_rd_active = 14107;

// output value
        public const NodeId pcm_out0 = 11279;
        public const NodeId pcm_out1 = 11240;
        public const NodeId pcm_out2 = 11202;
        public const NodeId pcm_out3 = 11251;
        public const NodeId pcm_out4 = 10939;
        public const NodeId pcm_out5 = 10916;
        public const NodeId pcm_out6 = 10881;
        public const NodeId _pcm_out4 = 11143;
        public const NodeId _pcm_out5 = 11103;
        public const NodeId _pcm_out6 = 10984;

        // specials
        public const NodeId pcm_decrement = 10819;
        public const NodeId pcm_increment = 10944;
        public const NodeId pcm_doadjust = 11386;
        public const NodeId pcm_overflow = 10818;
        public const NodeId pcm_dma__active_low_rdy = 11483;
        public const NodeId pcm_dma_active = 14059;
        public const NodeId pcm_dma__active_low_active = 14058;

// Sprite DMA
// DMA Engine signals
        public const NodeId spr__active_low_startdma = 14126;
        public const NodeId spr_startdma = 14117;
        public const NodeId spr_dma__active_low_rdy = 14063;

// value written to $4014
        public const NodeId spr_page0 = 13824;
        public const NodeId spr_page1 = 13854;
        public const NodeId spr_page2 = 13878;
        public const NodeId spr_page3 = 13908;
        public const NodeId spr_page4 = 13935;
        public const NodeId spr_page5 = 13966;
        public const NodeId spr_page6 = 13988;
        public const NodeId spr_page7 = 14015;
        public const NodeId spr__active_low_page0 = 13831;
        public const NodeId spr__active_low_page1 = 13861;
        public const NodeId spr__active_low_page2 = 13891;
        public const NodeId spr__active_low_page3 = 13916;
        public const NodeId spr__active_low_page4 = 13945;
        public const NodeId spr__active_low_page5 = 13975;
        public const NodeId spr__active_low_page6 = 13995;
        public const NodeId spr__active_low_page7 = 14021;

// Sprite DMA address counter
        public const NodeId spr_addr0 = 13337;
        public const NodeId spr_addr1 = 13409;
        public const NodeId spr_addr2 = 13482;
        public const NodeId spr_addr3 = 13552;
        public const NodeId spr_addr4 = 13617;
        public const NodeId spr_addr5 = 13675;
        public const NodeId spr_addr6 = 13730;
        public const NodeId spr_addr7 = 13790;
        public const NodeId spr_addr8 = 13824;
        public const NodeId spr_addr9 = 13854;
        public const NodeId spr_addr10 = 13878;
        public const NodeId spr_addr11 = 13908;
        public const NodeId spr_addr12 = 13935;
        public const NodeId spr_addr13 = 13966;
        public const NodeId spr_addr14 = 13988;
        public const NodeId spr_addr15 = 14015;
        public const NodeId spr__plus_addr0 = 11122;
        public const NodeId spr__plus_addr1 = 11162;
        public const NodeId spr__plus_addr2 = 11199;
        public const NodeId spr__plus_addr3 = 11232;
        public const NodeId spr__plus_addr4 = 11285;
        public const NodeId spr__plus_addr5 = 11314;
        public const NodeId spr__plus_addr6 = 11340;
        public const NodeId spr__plus_addr7 = 11364;
        public const NodeId spr__plus_addr8 = 13822;
        public const NodeId spr__plus_addr9 = 13853;
        public const NodeId spr__plus_addr10 = 13877;
        public const NodeId spr__plus_addr11 = 13906;
        public const NodeId spr__plus_addr12 = 13933;
        public const NodeId spr__plus_addr13 = 13963;
        public const NodeId spr__plus_addr14 = 13987;
        public const NodeId spr__plus_addr15 = 14014;
        public const NodeId spr__active_low_addr0 = 11107;
        public const NodeId spr__active_low_addr1 = 11139;
        public const NodeId spr__active_low_addr2 = 11188;
        public const NodeId spr__active_low_addr3 = 11221;
        public const NodeId spr__active_low_addr4 = 11263;
        public const NodeId spr__active_low_addr5 = 11302;
        public const NodeId spr__active_low_addr6 = 11331;
        public const NodeId spr__active_low_addr7 = 11354;
        public const NodeId spr__active_low_addr8 = 13831;
        public const NodeId spr__active_low_addr9 = 13861;
        public const NodeId spr__active_low_addr10 = 13891;
        public const NodeId spr__active_low_addr11 = 13916;
        public const NodeId spr__active_low_addr12 = 13945;
        public const NodeId spr__active_low_addr13 = 13975;
        public const NodeId spr__active_low_addr14 = 13995;
        public const NodeId spr__active_low_addr15 = 14021;

        public const NodeId spr_data0 = 13254;
        public const NodeId spr_data1 = 13253;
        public const NodeId spr_data2 = 13252;
        public const NodeId spr_data3 = 13251;
        public const NodeId spr_data4 = 13250;
        public const NodeId spr_data5 = 13249;
        public const NodeId spr_data6 = 13248;
        public const NodeId spr_data7 = 13247;
        public const NodeId spr__active_low_data0 = 13204;
        public const NodeId spr__active_low_data1 = 13203;
        public const NodeId spr__active_low_data2 = 13202;
        public const NodeId spr__active_low_data3 = 13201;
        public const NodeId spr__active_low_data4 = 13200;
        public const NodeId spr__active_low_data5 = 13199;
        public const NodeId spr__active_low_data6 = 13198;
        public const NodeId spr__active_low_data7 = 13197;

// current address being output - either spr_addr or $2004
        public const NodeId spr_a0 = 11129;
        public const NodeId spr_a1 = 11175;
        public const NodeId spr_a2 = 11211;
        public const NodeId spr_a3 = 11247;
        public const NodeId spr_a4 = 11294;
        public const NodeId spr_a5 = 11321;
        public const NodeId spr_a6 = 11345;
        public const NodeId spr_a7 = 11370;
        public const NodeId spr_a8 = 11379;
        public const NodeId spr_a9 = 11390;
        public const NodeId spr_a10 = 11403;
        public const NodeId spr_a11 = 11412;
        public const NodeId spr_a12 = 11423;
        public const NodeId spr_a13 = 11436;
        public const NodeId spr_a14 = 11442;
        public const NodeId spr_a15 = 11453;

        // Frame Counter

        // value written to $4017
        public const NodeId frm_intmode = 10713;
        public const NodeId frm__active_low_intmode = 13160;
        public const NodeId frm_seqmode = 10669;
        public const NodeId frm__active_low_seqmode = 10660;
        public const NodeId frm__active_low_seqmode_clk1 = 10724;
        public const NodeId frm__active_low_seqmode_clk1a = 13050;

// timer LFSR
        public const NodeId frm_xor_int = 10238;
        public const NodeId frm_xor_out = 10226;
        public const NodeId frm_t0_in = 12464;
        public const NodeId frm__active_low_t0_in = 12463;
        public const NodeId frm__active_low_t0 = 12458;
        public const NodeId frm_t0 = 12470;
        public const NodeId frm_t1_in = 12512;
        public const NodeId frm__active_low_t1_in = 12511;
        public const NodeId frm__active_low_t1 = 12510;
        public const NodeId frm_t1 = 12517;
        public const NodeId frm_t2_in = 12553;
        public const NodeId frm__active_low_t2_in = 12552;
        public const NodeId frm__active_low_t2 = 12551;
        public const NodeId frm_t2 = 12564;
        public const NodeId frm_t3_in = 12584;
        public const NodeId frm__active_low_t3_in = 12583;
        public const NodeId frm__active_low_t3 = 12580;
        public const NodeId frm_t3 = 12595;
        public const NodeId frm_t4_in = 12623;
        public const NodeId frm__active_low_t4_in = 12622;
        public const NodeId frm__active_low_t4 = 12620;
        public const NodeId frm_t4 = 12634;
        public const NodeId frm_t5_in = 12672;
        public const NodeId frm__active_low_t5_in = 12671;
        public const NodeId frm__active_low_t5 = 12666;
        public const NodeId frm_t5 = 12674;
        public const NodeId frm_t6_in = 12705;
        public const NodeId frm__active_low_t6_in = 12704;
        public const NodeId frm__active_low_t6 = 12701;
        public const NodeId frm_t6 = 12708;
        public const NodeId frm_t7_in = 12733;
        public const NodeId frm__active_low_t7_in = 12732;
        public const NodeId frm__active_low_t7 = 12731;
        public const NodeId frm_t7 = 12736;
        public const NodeId frm_t8_in = 12770;
        public const NodeId frm__active_low_t8_in = 12769;
        public const NodeId frm__active_low_t8 = 12762;
        public const NodeId frm_t8 = 12781;
        public const NodeId frm_t9_in = 12795;
        public const NodeId frm__active_low_t9_in = 12794;
        public const NodeId frm__active_low_t9 = 12789;
        public const NodeId frm_t9 = 12810;
        public const NodeId frm_t10_in = 12855;
        public const NodeId frm__active_low_t10_in = 12854;
        public const NodeId frm__active_low_t10 = 12851;
        public const NodeId frm_t10 = 12857;
        public const NodeId frm_t11_in = 12883;
        public const NodeId frm__active_low_t11_in = 12882;
        public const NodeId frm__active_low_t11 = 12881;
        public const NodeId frm_t11 = 12888;
        public const NodeId frm_t12_in = 12910;
        public const NodeId frm__active_low_t12_in = 12909;
        public const NodeId frm__active_low_t12 = 12908;
        public const NodeId frm_t12 = 12911;
        public const NodeId frm_t13_in = 12933;
        public const NodeId frm__active_low_t13_in = 12932;
        public const NodeId frm__active_low_t13 = 12931;
        public const NodeId frm_t13 = 10218;
        public const NodeId frm_t14_in = 12957;
        public const NodeId frm__active_low_t14_in = 12956;
        public const NodeId frm__active_low_t14 = 12953;
        public const NodeId frm_t14 = 10225;

        // frame phases
        public const NodeId frm_phase_a = 10245; // 100001100000100
        public const NodeId frm_phase_b = 10185; // 110000000110110
        public const NodeId frm_phase_c = 10231; // 110010110011010
        public const NodeId frm_phase_d = 10154; // 111110000101000 AND frm_seqmode = 1
        public const NodeId frm_phase_e = 10170; // 101000011000111
        public const NodeId frm_phase_force_reset = 10244; // 000000000000000

// frame phase triggers
        public const NodeId frm__active_low_quarter = 10293;
        public const NodeId frm__active_low_half = 10563;

// Frame signals
        public const NodeId frm_lfsr_advance = 10264;
        public const NodeId frm_lfsr_reset = 10265;
        public const NodeId frm_mode_advance__active_low_reset = 13001;
        public const NodeId frm_mode__active_low_advance_reset = 12991;
        public const NodeId frm_queue_reset = 10778;
        public const NodeId frm_queue_reset_clk1 = 10752;
        public const NodeId frm_reset_from_write = 10631;
        public const NodeId frm_mode1_reset_clock = 10159;
        public const NodeId frm_suppress_phase_d = 13072;

        // APU clock phases
        public const NodeId apu_clk1 = 11434;
        public const NodeId apu__active_low_clk2 = 10533;
        public const NodeId apu_clk2a = 11505; // $4015
        public const NodeId apu_clk2b = 10130; // sq0
        public const NodeId apu_clk2c = 10131; // sq1
        public const NodeId apu_clk2d = 10180; // $4016
        public const NodeId apu_clk2e = 10988; // PCM-related

        // IRQ sources
        public const NodeId pcm_irq = 11522;
        public const NodeId active_low_pcm_irq = 11492;
        public const NodeId set_pcm_irq = 14120;
        public const NodeId pcm_irq_out = 10753;

        public const NodeId frame_irq = 13110;
        public const NodeId active_low_frame_irq = 10697;
        public const NodeId active_low_frame_irq_clk1 = 13171;
        public const NodeId r4015_d6_high = 10728;
        public const NodeId r4015_d6_low = 13174;
        public const NodeId ack_frame_irq_r4015 = 13170;

        public const NodeId irq_internal = 10775;
        public const NodeId irq_external = 11198;

        // $401A bit 7
        public const NodeId snd_halt = 10658;
        public const NodeId active_low_snd_halt = 13426;

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
