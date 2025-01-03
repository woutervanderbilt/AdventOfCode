﻿using Algorithms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Problems.Advent._2018;

public class Dag13 : Problem
{
    private const string input = @"                    /--------------------------------------------------------------------------------------------------\                              
                    |                                     /-------------------------------------------------------\    |/-----------\                 
                    | /-----------------------------------+-----------------------------------\                   |   /++---------\ |                 
              /-----+-+--------------\                    |                                /--+---------------\   |   |||         | |                 
              |     | |/-------------+--------------------+---\                            |  |               |   |   |||         | |                 
              |   /-+-++-------------+--------------------+---+----<----------------------\|  |               |   |   |||         | |                 
              |   | | ||             | /------------------+---+---------------------------++--+---------------+---+---+++--\      | |                 
  /-----------+---+-+-++-------->----+-+------------------+---+---------------------------++--+-\       /-----+--\|   |||  |      | |                 
  |      /----+---+-+-++-------------+-+------------------+---+------\                    ||  | |       |     |  ||   |||  |      | |                 
  |      |    |  /+-+-++-------------+-+------------------+---+------+--------------------++--+-+-------+-----+--++---+++--+-\    | |                 
  |      |    |  || |/++------------\| |                 /+---+------+-----------\        ||  | |       |     |  ||   |||  | |    | |                 
  |      |    |  || ||||            || |                /++---+--\   |  /--------+--------++--+-+-------+-----+--++---+++--+-+----+-+-------------\   
  |      |/---+--++\||||            || |             /--+++---+--+---+--+--------+--------++--+-+-------+-----+--++---+++--+-+----+-+----\        |   
  | /----++---+--+++++++-----\      || |     /-------+--+++---+--+---+--+--------+--------++--+-+-------+-----+--++---+++--+-+----+-+----+--------+--\
  | |    ||   |  |||||||     |      || |     |     /-+--+++---+--+---+--+--------+--------++--+-+-------+-----+--++---+++--+-+----+-+----+---\    |  |
  | |    ||   |  |||||||     |      || |     |     |/+--+++---+--+---+--+--------+--------++--+-+-------+-----+-\||   |||  | |    | |    |   |    |  |
  | |    ||   |  |||||||     |      || |     |     |||  |||   |  |   |  |        |  /-----++--+-+-------+-----+-+++---+++--+-+----+\|    |   |    |  |
  | |    ||   |  |||||||     |      || |     |     |||  |||   |  |   |  |        |  |     ||  | |       |     | |||   |||  |/+----+++----+---+--\ |  |
  | |    ||   |  |||||||     |      || |     |  /--+++--+++---+--+---+--+--------+--+-----++--+-+-------+-----+-+++---+++--+++----+++-\  |   |  | |  |
  | |    ||/--+--+++++++-----+------++-+-----+--+--+++--+++---+--+---+--+--------+--+-----++--+-+------\|     | |||   |||  |||    ||| |  |   |  | |  |
  | |    |||  |  |||||||     |      || |     |  |  |||  |||   |  |   |  |        |  |     |\--+-+------++-----/ |||   |||  |||    ||| |  |   |  | |  |
/-+-+----+++--+--+++++++-----+------++-+---\ |  |  |||  \++---+--/   |  |        |  |     |   | |      ||       |||   |||  |||    ||| |  |   |  | |  |
| | |    |||  |  |||||||     |      || |   | |  |  |||   ||   |      |  |        | /+-----+---+-+------++-------+++--\|||  |||    ||| |/-+---+--+-+-\|
| | |    |||  |  |||||||     |      || |   | |  |  |||   \+---+------+--+--------/ || /---+---+-+------++-------+++--++++--+++----+++-++-+-\ |  | | ||
| | |    |||  |  |||||||     |      || |   | |  |  |||    |   |      |  | /--------++-+---+---+-+------++-------+++-\||||  |||    ||| || | | |  | | ||
| | |    |||  |  ||||||\-----+------++-+---+-+--+--+++----+---/      |  | |     /--++-+---+---+-+------++------\||| ||\++--+++----/|| || | | |  | | ||
| | |    |||  \--++++++------+------+/ |   | |  |  |||    |          |  | |     |  || |   |   | |      ||      |||| || ||  |||     || || | | |  | | ||
| |/+----+++--\  |||||\------+------+--+---+-+--+--+++----+----------+--+-+-----+--++-+---+---/ |      ||      |||| || ||  |||     || || | | |  | | ||
|/+++----+++--+--+++++-------+\     |  |   | |/-+--+++----+----------+--+-+-----+--++-+---+-----+------++------++++-++-++--+++-----++-++-+-+-+\ | | ||
|||||    |||  |  |||||       ||     |  |   | || |  |||    |          |  | |  /--+--++-+---+-----+------++------++++-++-++--+++\    || || | | || | | ||
|||||    \++--+--+++++-------++-----+--+---+-++-+--+++----+----------/  | |  |  |  || |   |     | /----++------++++-++-++--++++----++-++-+-+\|| | | ||
|||||     ||  |  |||||       ||     |/-+---+-++-+--+++----+-------------+-+--+--+--++-+--\|     | |    ||      |||| || ||  ||||    || || | |||| | | ||
|||||     ||  |  |||||       ||     || |   | || |  ||| /--+-------------+-+--+--+--++-+--++-----+-+-\  ||      |||| || ||  ||||    || || | |||| | | ||
|||||     ||  |  |||||       || /---++-+---+-++-+-<+++-+--+-----<-------+-+--+--+--++-+--++-\   | | |  ||      |||| || ||  ||||    || || | |||| | | ||
|||||     |\--+--+++++-------++-+---++-+---+-++-+--+++-+--+-------------+-+--+--+--++-+--++-+---+-+-+--/|      |||| || ||  ||||    || || | |||| | | ||
||||\-----+---+--+++++-------/| |   || |   | || |  ||| |  |             | |  |  |  || |  || |   | | |   |      |||| || ||  ||||    || || | |||| | | ||
|||\------+---/ /+++++--------+-+-\ || |   | || |  ||| |  |             | |  |  |  || |  || |   | | |   |      |||| || ||  ||||    || || | |||| | | ||
|||       |     |||||| /------+-+-+-++-+---+-++-+--+++-+--+-------------+-+--+--+--++-+--++-+---+-+-+---+------++++\|| ||  ||||    || || | |||| | | ||
|||       | /---++++++-+------+-+\| || |   |/++-+--+++-+--+-------------+-+--+--+--++-+--++-+---+-+-+---+------+++++++-++--++++-\  || || | |||| | | ||
|||       | |   |||||| |      | ||| || |   |||| |  ||| |  |             | |  |  | /++-+--++-+---+-+-+-\ | /----+++++++-++--++++-+--++-++-+-++++-+-+\||
|||       | |   |||||| |      | ||| || |/--++++-+--+++-+--+-------------+-+--+--+-+++-+--++-+---+-+-+-+-+-+---\||||||| ||  |||| |  || || | |||| | ||||
|||/------+-+---++++++-+---\  | ||| || || /++++-+--+++-+--+-------------+-+--+--+-+++-+--++-+\  | | | | | |   |||||||| ||  |||| |  || || | |||| | ||||
||||      | |   |||||| | /-+--+-+++-++-++-+++++-+--+++-+--+-------------+-+--+--+-+++\|  || ||  | | | | | |   |||||||| |\--++++-+--+/ || | |||| | ||||
||||      | |   |||||| | | |  | ||| || || ||||| |  ||| |  |             | |  |  | |||||  || ||  | \-+-+-+-+---++++++++-+---++++-+--+--++-+-+/|| | ||||
||||      | |  /++++++-+-+-+--+-+++-++-++-+++++-+--+++-+--+--\          | |  |  | |||||  || ||  |   | | | |   |||||||| |   |||| |  |  || | | || | ||||
||||      | |  ||||||| | | |  | ||| || || ||||| |  ||| |  |  |        /-+-+--+-\| |||||  || ||  |   | | | |   |||||||| |   |||| |  |  || | | || | ||||
||||/-----+-+--+++++++-+-+-+--+-+++-++-++-+++++-+--+++-+--+--+----\   | | |  |/++-+++++--++-++--+---+-+-+-+---++++++++-+--\|||| | /+--++-+-+\|| | ||||
|||||     | |  |||||\+-+-+-+--+-+++-++-++-+++++-+--+++-+--+--+----+---+-+-+--++++-+++++--++-++--+---+-+-+-+---++++++++-/  ||||| | ||  || | |||| | ||||
|||||   /-+-+--+++++-+-+-+-+--+-+++-++-++-+++++\|  ||\-+--+--+----+---+-+-+--++++-+++++--++-++--+---+-+-+-+---++++++++----+++++-+-++--++-/ |||| | ||||
|||||   |/+-+--+++++-+-+-+-+--+-+++-++-++-+++++++--++--+--+--+-\  |   |/+-+--++++-+++++--++-++--+---+-+-+-+---++++++++----+++++-+-++--++-\ |||| | ||||
|||||   ||| |  ||||| | | | |  | ||| || || ||||||| /++--+--+--+-+--+-\ ||| |  |||| |||||  || ||  |/--+-+-+-+---++++++++----+++++-+-++--++-+-++++\| ||||
|||||   ||| |  ||||| | | | |  | ||| || || ||||||| |||  |  |  | |  | | ||| |  |||| |||||  || ||  ||  | | | |   ||||||||    ||\++-+-++--++-+-+++++/ ||||
|||||   ||| |  ||||| | | | |/-+-+++-++-++-+++++++-+++--+--+--+-+--+-+\||| |  ||||/+++++--++-++--++--+-+-+-+---++++++++----++-++-+-++--++-+-+++++\ ||||
|||||   ||| |  ||||| | | | || | ||| || || ||||||| |||  |  |  | |  | ||||| |  ||||||||||  ^| ||  ||  | | | |   ||||||||    || || | ||  || | |||||| ||||
|||||   ||| |  ||||| | | | || | ||| ||/++-+++++++-+++--+--+--+\|  | ||||| |  \+++++++++--++-++--++--+-+-+-+---++++++++----++-+/ | ||  || | |||||| ||||
|||||   ||| |  ||||| | | |/++-+-+++-+++++-+++++++-+++--+--+--+++--+-+++++-+---+++++++++--++-++--++--+-+-+-+---++++++++----++-+-\| ||  || | |||||| ||||
|||||   ||| |  ||||| | | |||| | ||| ||||| ||||||| |||/-+--+--+++--+-+++++-+---+++++++++--++-++--++--+-+-+\|   ||||||||    || | || ||  || | |||||| ||||
|||||   |||/+--+++++-+-+-++++-+-+++-+++++-+++++++-++++-+--+--+++-\| ||||| |   ||\++++++--++-++--++--+-+-+++---+/||||||    || | || ||  || | |||||| ||||
|||||   |||||  ||||| | ^ |||| | ||| |||\+-+++++++-++++-+--+--+++-++-+++++-+---++-++++++--++-++--++--+-+-+++---+-++++++<---+/ | || ||  || | |||||| ||||
|||||   |||||  ||||| | | \+++-+-+++-+++-+-+++++++-++++-+--+--+++-++-+++++-+---++-++++/|  || ||  ||  | | |||   | ||||||    |  | || ||  || | |||||| ||||
||\++---+++++--+++++-+-+--+++-+-+++-+++-+-+++++++-++++-+--+--+++-++-+++++-+---++-++++-+--++-++--/|  | | |||   | ||||||    |  | || ||  || | |||||| ||||
|| ||   |||||  ||||| | |  ||| | ||| ||| | ||||||| |||| |  |  ||| || |||||/+---++-++++-+--++-++---+--+-+-+++---+-++++++----+--+-++-++--++-+\|||||| ||||
|| ||   |||||  ||||| | |  ||| | ||| ||| | ||||||| |||| |  |  ||| || |||||||   || ||||/+--++-++---+--+-+-+++---+-++++++----+-\| || ||  || |||||||| ||||
|| ||   |||||  ||||| | |  ||| | ||| ||| | ||||||| |||| |  |  ||| || |||||||   || \+++++--++-++---+--+-+-+++---+-++++++--->+-++-++-++--++-+++++++/ ||||
|| ||   |||||  ||||| | |  ||| | ||| ||| | ||||||| |\++-+--+--+++-++-+++++++---++--+++++--++-++---+--+-+-+++---+-++++++----+-++-++-++--++-++++/||  ||||
\+-++---+++++--+++++-+-+--+++-+-+++-+++-+-+/||||| | || |  |  ||| || |||||||   ||  |||||  || ||   |  | | |||   | ||||||    | || || ||  || |||| ||  ||||
/+-++---+++++--+++++-+-+--+++-+-+++-+++-+-+-+++++-+-++-+--+-\||| || |||||||   ||  |||||  || ||   |  | | |||   | ||||||    | || || ||  || |||| ||  ||||
|| ||   |||||  ||||| | |  ||| | ||| ||| | | ||||| |/++-+--+-++++-++-+++++++---++--+++++--++-++---+--+-+\||\---+-++++++----+-++-++-++--++-++++-++--+/||
|| ||   |||||  ||||| | |  \++-+-+++-+++-+-+-+++++-++++-+--+-++++-++-+++++++---++--+++++--++-++---+--+-++++----+-++++++----+-++-/| ||  || |||| ||  | ||
|| ||   |||||  ||^\+-+-+---++-+-+++-+++-+-+-+++++-++++-+--+-++++-++-+++++++---++--+++++--+/ ||   |  | ||||    | ||||||/---+-++--+-++--++-++++-++\ | ||
|| ||   |||||  ||| | | |   || | ||| ||| | | ||||\-++++-+--+-++++-++-+++++++---++--+++++--+--++---+--+-++++----+-+++++++---+-++--+-++--/| |||| ||| | ||
|| ||   |||||  ||| | | |   || |/+++-+++-+\| ||||  |||| |  | |||| || |||||||   ||  |||||  |  ||   |  | ||||    | |||||||   | ||  | ||   | |||| ||| | ||
|| ||   |||||  ||| | | |   || ||||| ||| ||| \+++--++++-+--+-++++-++-+++++++---++--+++++--+--++---+--+-++++----+-+++++++---+-++--/ ||   | |||| ||| | ||
|^ ||   |||||  ||| | | |   || ||||| ||| |||  |||  |||| |  | |||| || |||||||   ||  |||||  |  ||   |  | ||||    | |||||||   | ||    ||   | |||| ||| | ||
|| ||   |||||  ||| | | |   || ||||| ||| |||  |||  |||| | /+-++++-++-+++++++---++--+++++--+--++---+--+-++++----+-+++++++---+-++----++---+-++++-+++\| ||
|| ||  /+++++--+++-+-+-+---++-+++++-+++-+++--+++--++++-+-++-++++-++\|||||||   ||  |||\+--+--++---+--+-++++----+-+++++++---+-/|    ||   | |||| ||||| ||
|| ||  |||||| /+++-+-+-+---++\||||| ||| |||  |||  |||| | || |||| ||||||||||   \+--+++-+--+--++---+--+-++++----+-+++++++---/  |    ||   | |||| ||||| ||
|| ||  |||||| |||| | | |   |||||||| ||| |||  |||  |||| | |\-++++-++++++++++----+--+++-+--+--++---+--+-++++----+-++/||||      |    ||   | |||| ||||| ||
\+-++--++++++-++++-+-+-+---++++++++-+++-+++--+++--++++-+-+--/||| ||||||||||    |  \++-+--+--++---+--+-/|||  /-+-++-++++-\    |    ||   | |||| ||||| ||
 |/++--++++++-++++-+-+-+---++++++++-+++-+++--+++--++++\| |  /+++-++++++++++----+---++-+--+-\||   |  |  |||  | | || ||||/+----+---\||   | |||| ||||| ||
 ||||  |||||| |||| | | |   |||||||| ||| |||  |||  |||||| |  |||| ||||||||||    |   || |  | |||   |  |  |||  | | || ||||||    |   |||   | |||| ||||| ||
 ||||  |||||| |||| | | |   |||||||| ||| |||  \++--++++++-+--++++-++++++++++----+---++-+--+-+++---+--+--+++--+-+-++-++++++----+---+++---+-++++-+++++-+/
 ||||  |||\++-++++-/ | \---++++++++-+++-+++---++--++++++-+--++++-++++++++++----+---++-+--+-+++---+--+--+++--+-+-++-/|||||    |   |||   | |||| ||||| | 
 ||||  ||| || ||||   |     |||||||| ||| |||   ||  |||||\-+--++++-++++++++++----+---++-+--+-+++---+--/  |||  | | ||  |||||    |   |||   | |||| ||||| | 
 ||||  ||| || ||||   |     ||||||||/+++-+++---++--+++++--+--++++-++++++++++----+---++-+--+-+++--\|     |||  | | ||  |||||    |   |||   | |||| ||||| | 
 ||||  ||| || ||||  /+-----++++++++++++-+++---++--+++++--+--++++-++++++++++----+---++-+\ | |||  ||     |||  | | ||  ||\++----+---+++---+-++++-++/|| | 
 |||\--+++-++-++++--++-----++++++++++++-+++---++--+++++--+--++++-+/||||||||    |   || || | |||  ||     |||  | | ||  || ||    |   |||   | |||| || || | 
 |||   ||| || ||||  ||     |||||||||||| |||   ||  |||||  |/-++++-+-++++++++----+---++-++-+-+++--++-----+++-\| | ||  || ||    |   |||   | |||| || || | 
 |||   ||| || ||||  ||     |||||||||||| |||   ||  |||||  || |||| | ||||||||    |   || || | |||  ||     ||| || | ||  || ||    |   |||   | |||| || || | 
 |||   ||| || ||||  ||     |||||||||||| |||   || /+++++--++-++++-+-++++++++----+---++-++-+-+++--++-----+++-++-+-++--++-++----+---+++---+\|||| || || | 
 |||/--+++-++-++++--++-----++++++++++++-+++---++-++++++--++-++++-+-++++++++----+---++-++-+-+++\ ||     ||| || | ||  || ||    |   |||   |||||| || || | 
 ||||  ||| || ||||  ||     |||||||||||| |||   || ||||||  || |||| | ||||||||    |   || || | |||| ||     ||| || | ||  || ||    |   |||   |||||| || || | 
 ||||  ||| || ||||  ||     |||||||||||| |||   || ||||||  || |||| | ||||||||    |   || \+-+-++++-++-----+++-++-+-++--++-++----+---+++---++++/| || || | 
 ||||  ||| || ||||  ||     |||||||||||| |||   || ||||||  || |||| | ||||||||    |   |\--+-+-++++-++-----+++-++-+-++--++-++----+---++/   |||| | || || | 
 \+++--+++-++-++++--++-----+++/|||||||| |||   || ||||||  || |||| | ||||||||    |   |   | | |||| |^     ||| || | ||  || ||    |   ||    |||| | || || | 
  |||  ||| || ||||  ||     ||| |||||||| |||   || ||\+++--++-++++-+-++++++++----+---+---+-+-++++-++-----/|| || | ||  || ^|    |   ||    |||| | || || | 
  |||  \++-++-++++--++-----+++-++++++++-+++---++-++-+++--++-++++-+-/|||||||    |   |   | | |||| ||      || || | ||  || ||    |   ||    |||| | || || | 
  |||   || || ||||  ||     ||| |||||||| |||   || || |||  || |||| |  ||\++++----/   |   |/+-++++-++------++-++-+-++--++-++---\|   ||    |||| | || || | 
  |||   || || ||||  ||     ||| |||||||| |||   || || |||  || |||| |  || ||||      /-+---+++-++++-++------++-++-+-++--++-++---++---++----++++-+-++\|| | 
  |||   || || ||||  ||     ||| |||||||| |||   || || |||  || \+++-+--++-++++------+-+---+++-/||| ||      || || | ||  || ||   ||   ||    |||| | ||||| | 
  |||  /++-++-++++--++-----+++-++++++++-+++---++-++-+++--++--+++-+--++-++++------+-+---+++--+++-++\/----++-++-+-++--++-++---++---++----++++-+\||||| | 
  |||  ||| || ||||  ||     ||| |||||||\-+++---++-++-+++--++--+/| |  || ||||      | |   |||  ||| ||||    || || | ||  || ||   ||   ||    |||| ||||||| | 
  |||  ||| || |||\--++-----+++-+++++++--+++---++-++-+++--++--+-+-+--++-++++------+-+---+++--+++-++++----++-++-+-++--++-++---+/   ||    |||| ||||||| | 
  |||  ||| || |||   ||     ||| |||||||  |||   || || \++--++--+-+-+--++-++++------+-+---+++--+++-++++----++-++-+-/|  || ||   |    ||    |||| ||||||| | 
  \++--+++-++-+++---++-----+++-+++++++--+++---++-++--+/  ||  |/+-+--++-++++------+-+---+++--+++-++++----++\|| |  |  || ||   |    ||    |||| ||||||| | 
   ||  ||| || |||   \+-----+++-+++++++--+++---++-++--+---++--+++-+--++-++++------+-+---/||  ||| ||||    ||||| |  |  || ||   |    ||    |||| ||||||| | 
   ||  ||| || |||    \-----+++-+++++/|  |||   || ||  \---++--+++-+--++-++++------+-+----++--+++-++++----+/||| |  |  || ||   |    ||    |||| ||||||| | 
   ||  ||| || |||          ||| \++++-+--+/|   \+-++------++--+++-+--++-++++------+-+----++--+++-++++----+-+++-+--+--++-++---+----++----++++-++/|||| | 
   ||  ||| || |||          |||  |||| |  | |    | ||      ||  ||| | /++-++++------+-+-\  ||  ||| ||||    | ||| |  |  || ||   |    ||    |||| || |||| | 
   ||  ||| || |||/---------+++--++++-+--+-+----+-++------++--+++-+-+++-++++------+-+-+--++-\||| ||||    | ||| |  |  || ||   |    ||    |||| || |||| | 
   ||  ||| || ||||         |||  |||| |  \-+----+-++------++--+++-+-+++-++++------+-+-+--++-++++-++++----+-+++-/  |  || ||   |    ||    |||| || |||| | 
   ||  ||| || ||||         |||  |||| |    |    | ||      ||  ||| | ||| |\++------+-+-+--++-++++-++++----+-+++----+--++-++---+----++----++++-++-+++/ | 
   ||  ||| || ||||         |||  |||| \----+----+-++------++--+++-+-+++-+-++------+-+-+--+/ |||| ||||    | |||    |  || ||   |    ||    |||| || |||  | 
   ||  ||| |\-++++---------+++--+/||      |    | ||      ||  ||| | ||| | ||      | | |  |  |||| ||||    \-+++----/  || ||   |    ||    \+++-++-+++--/ 
   ||  ||| |  ||||  /------+++--+-++\     |    | ||      ||  ||| | ||| | \+------+-+-+--+--++++-++++------+++-------++-++---+----++-----++/ || |||    
   ||  ||| |  ||||  |      |||  \-+++-----+----+-++------++--+++-+-+++-+--+------+-+-+--+--+/|| ||||      |||       || ||   |    ||     ||  || |||    
   ||  ||| |  ||||  |      |||    |||     |    | ||      ||  ||| | ||| |  |      | | |  |  | || ||||      |||       || ||   |    ||     ||  || |||    
   ||  ||| |  |||| /+------+++----+++-----+----+-++------++--+++-+-+++-+--+------+-+-+--+--+-++-++++------+++-----\ || ||   |    ||     ||  || |||    
   ||  ||| |  |||| ||      |\+----+++-----+----+-++------++--+++-+-++/ |  |      | |/+--+--+-++-++++------+++-----+-++-++---+----++----\||  || |||    
   ||  ||| |  |||| ||      | |    |||     |    | ||      ||  |\+-+-++--+--+------+-+++--+--+-++-++++------/||  /--+-++-++---+\   ||    |||  || |||    
   \+--+++-+--++++-++------/ |    |||     \----+-++------++--+-+-+-++--+--+------+-+++--+--+-/| ||||       ||  |  | || ||   ||   ||    |||  || |||    
    |  ||| |  |\++-++--------+----+++----------+-++------++--/ | | \+--+--+------+-++/  |  |  | ||||       ||  |  | || ||   ||   ||    |||  || |||    
    |  ||| |  | || ||    /---+----+++----------+\||      ||    | |  |  |  |      | ||   |  |  | ||||       ||  |  | || ||   ||   ||    |||  || |||    
    |  ||| |  | || ||    |   |    |||          ||||      ||    | |  |  |  |      | ||   \--+--+-++++-------++--+--+-++-++---/|   ||    |||  || |||    
    |  ||| |  | || ||    |   |    |||          ||||      ||    | |  |  |  |      | \+------+--+-++++-------++--+--+-+/ \+----+---/|    |||  || |||    
    |  ||| |  | || ||    |   |    |||          ||||      ||    | |  |  |  \------+--+------+--+-++++-------++--+--+-/   |    |    |    |||  || |||    
    \--+++-+--+-++-++----+---+----+++----------++++------++----+-+--+--+----<----+--+------+--/ ||||       ||  |  |     |    |    |    |||  || |||    
       \++-+--+-++-++----+---+----+++----------++++------++----+-+--+--+---------+--+------+----++/|       ||  |  |     |    |    |    |||  || |||    
        || |  | || ||    |   |    |||     /----++++------++----+-+--+--+---------+--+------+----++-+-------++--+-\|     |    |    |    |||  || |||    
        || |  | || ||/---+---+----+++-----+----++++------++----+-+--+--+---------+--+------+----++-+-------++--+-++-----+----+-\  |    |||  || |||    
        || |  | || |||   |   |    |||     |    ||||      ||    | |  |  |         \--+------+----++-+-------++--+-++-----+----+-+--+----+++--++-+/|    
        |\-+--+-++-+++---+---+----+++-----+----++++------++-<--/ |  |  |            |      |    || |       ||  | ||     |    | |  |    |||  || | |    
        |  |  | || |||   |   |    |||     |    ||||      ||      |  |  |            |      |    || \-------++--+-++-----+----+-+--+----+++--+/ | |    
       /+--+--+-++-+++---+---+----+++-----+----++++------++------+--+--+------------+----\ |    ||         ||  | ||     |    | |  |    |||  |  | |    
       ||  |  | |\-+++---+---+----+++-----+----++++------++------+--+--+------------+----+-/    ||         ||  | ||     |    | |  |    |||  |  | v    
       ||  |  | |  |||   |   |    |\+-----+----++++------++------+--+--+------------+----+------/|         ||  | ||     |    | |  |    |||  |  | |    
       ||  |  | |  \++---+---+----+-+-----+----++++------++------+--+--+------------+----+-------+---------++--+-+/     |    | |  |    |||  |  | |    
       ||  |  \-+---++---+---/    | |     \----++++------++------+--+--+------------+----+-------+---------++--+-/      |    | |  |    |||  |  | |    
       ||  |    \---++---+--------/ |          ||||      ||      |  |  |            |    |       |         |\--+--------/    | |  |    |||  |  | |    
       ||  |        ||   |          |          ||||      ||      |  |  |            \----+-------+---------+---+-------------+-+--+----/||  |  | |    
       ||  \--------++---+----------+----------++++------++------/  |  |                 |       |         |   |             | |  |     ||  |  | |    
       ||           ||   |          |          ||||      ||         |  \-----------------+-------+---------+---+----<--------+-+--+-----+/  |  | |    
       ||           |\---+----------+----------++++------++---------+--------------------+-------+---------+---+-------------+-/  |     |   |  | |    
       ||           |    |          |          |||\------++---------/                    |       |         |   |             |    |     |   |  | |    
       |\-----------+----+----------+----------/||       ||                              |       \---------+---+-------------+----+-----+---+--/ |    
       \------------+----+----------+-----------++-------++------------------------------/                 |   |             |    \-----+---/    |    
                    |    |          |           ||       \+------------------------------------------------+---+-------------+----------+--------/    
                    |    \----------+-----------/|        \------------------------------------------------/   |             |          |             
                    \---------------/            |                                                             \-------------/          |             
                                                 \--------------------------------<-----------------------------------------------------/             ";

    private const string testInput = @"/->-\        
|   |  /----\
| /-+--+-\  |
| | |  | v  |
\-+-/  \-+--/
  \------/";


    public override Task ExecuteAsync()
    {
        IDictionary<Coordinate, TrackPart> track = new Dictionary<Coordinate, TrackPart>();
        IList<Cart> carts = new List<Cart>();
        int rowNumber = 0;
        int cartId = 1;
        foreach (var row in input.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
        {
            int columnNumber = 0;

            foreach (var location in row)
            {
                if (location != ' ')
                {
                    TrackPart newTrackpart;
                    var coordinate = new Coordinate(rowNumber, columnNumber);
                    if (location == '<' || location == '>')
                    {
                        newTrackpart = new TrackPart
                        {
                            Coordinate = coordinate,
                            Type = '-'
                        };
                        var cart = new Cart
                        {
                            Id = cartId++,
                            Direction = location == '<' ? Direction.West : Direction.East,
                            Location = newTrackpart,
                            NextCrossingChange = DirectionChange.Left
                        };
                        newTrackpart.Occupant = cart;
                        carts.Add(cart);
                    }
                    else if (location == '^' || location == 'v')
                    {
                        newTrackpart = new TrackPart
                        {
                            Coordinate = coordinate,
                            Type = '|'
                        };
                        var cart = new Cart
                        {
                            Id = cartId++,
                            Direction = location == '^' ? Direction.North : Direction.South,
                            Location = newTrackpart,
                            NextCrossingChange = DirectionChange.Left
                        };
                        newTrackpart.Occupant = cart;
                        carts.Add(cart);
                    }
                    else
                    {
                        newTrackpart = new TrackPart
                        {
                            Coordinate = coordinate,
                            Type = location
                        };
                    }

                    track[coordinate] = newTrackpart;
                    var westNeighbourCoordinate = new Coordinate(coordinate.Row, coordinate.Column - 1);
                    var northNeighbourCoordinate = new Coordinate(coordinate.Row - 1, coordinate.Column);
                    if (track.ContainsKey(westNeighbourCoordinate))
                    {
                        var westNeighbour = track[westNeighbourCoordinate];
                        westNeighbour.EastNeighbour = newTrackpart;
                        newTrackpart.WestNeighbour = westNeighbour;
                    }

                    if (track.ContainsKey(northNeighbourCoordinate))
                    {
                        var northNeighbour = track[northNeighbourCoordinate];
                        northNeighbour.SouthNeighbour = newTrackpart;
                        newTrackpart.NorthNeighbour = northNeighbour;
                    }
                }

                columnNumber++;
            }

            rowNumber++;
        }

        int cartsLeft = carts.Count;
        int ticks = 0;
        while (cartsLeft > 1)
        {
            foreach (var cart in carts.OrderBy(c => c.Location.Coordinate.Row).ThenBy(c => c.Location.Coordinate.Column))
            {
                if (!cart.IsAnnihilated)
                {
                    cart.Move();
                    if (cart.IsAnnihilated)
                    {
                        cartsLeft -= 2;
                    }
                }
            }

            ticks++;
        }
        var remainingCart = carts.Single(c => !c.IsAnnihilated);
        Result = $"{remainingCart.Location.Coordinate}, cart {remainingCart.Id} after {ticks} ticks";

        return Task.CompletedTask;
    }

    public override int Nummer => 201813;

    private class TrackPart
    {
        public Coordinate Coordinate { get; set; }
        public char Type { get; set; }
        public bool IsOccupied => Occupant != null;
        public TrackPart NorthNeighbour { get; set; }
        public TrackPart EastNeighbour { get; set; }
        public TrackPart SouthNeighbour { get; set; }
        public TrackPart WestNeighbour { get; set; }
        public Cart Occupant { get; set; }
        public TrackPart Leave(Cart cart)
        {
            Occupant = null;
            switch (cart.Direction)
            {
                case Direction.North:
                    return NorthNeighbour;
                case Direction.East:
                    return EastNeighbour;
                case Direction.South:
                    return SouthNeighbour;
                case Direction.West:
                    return WestNeighbour;
            }

            return null;
        }
        public void Accept(Cart cart)
        {
            if (IsOccupied)
            {
                Console.WriteLine($"Collision at {Coordinate}, carts {cart.Id} and {Occupant.Id}");
                cart.IsAnnihilated = true;
                Occupant.IsAnnihilated = true;
                Occupant = null;
                return;
            }

            cart.Location = this;
            Occupant = cart;
            cart.ChangeDirection(Type);
        }
    }

    private class Cart
    {
        public int Id { get; set; }
        public TrackPart Location { get; set; }
        public Direction Direction { get; set; }
        public DirectionChange NextCrossingChange { get; set; }
        public bool IsAnnihilated { get; set; }
        public void Move()
        {
            Location.Leave(this).Accept(this);
        }

        public void ChangeDirection(char type)
        {
            switch (type)
            {
                case '+':
                    if (NextCrossingChange == DirectionChange.Left)
                    {
                        switch (Direction)
                        {
                            case Direction.East:
                                Direction = Direction.North;
                                break;
                            case Direction.North:
                                Direction = Direction.West;
                                break;
                            case Direction.West:
                                Direction = Direction.South;
                                break;
                            case Direction.South:
                                Direction = Direction.East;
                                break;
                        }
                    }
                    else if (NextCrossingChange == DirectionChange.Right)
                    {
                        switch (Direction)
                        {
                            case Direction.East:
                                Direction = Direction.South;
                                break;
                            case Direction.North:
                                Direction = Direction.East;
                                break;
                            case Direction.West:
                                Direction = Direction.North;
                                break;
                            case Direction.South:
                                Direction = Direction.West;
                                break;
                        }
                    }
                    ChangeNextCrossingChange();
                    break;
                case '\\':
                    switch (Direction)
                    {
                        case Direction.East:
                            Direction = Direction.South;
                            break;
                        case Direction.North:
                            Direction = Direction.West;
                            break;
                        case Direction.West:
                            Direction = Direction.North;
                            break;
                        case Direction.South:
                            Direction = Direction.East;
                            break;
                    }
                    break;
                case '/':
                    switch (Direction)
                    {
                        case Direction.East:
                            Direction = Direction.North;
                            break;
                        case Direction.North:
                            Direction = Direction.East;
                            break;
                        case Direction.West:
                            Direction = Direction.South;
                            break;
                        case Direction.South:
                            Direction = Direction.West;
                            break;
                    }
                    break;
            }
        }

        private void ChangeNextCrossingChange()
        {
            if (NextCrossingChange == DirectionChange.Left)
            {
                NextCrossingChange = DirectionChange.Straight;
            }
            else if (NextCrossingChange == DirectionChange.Straight)
            {
                NextCrossingChange = DirectionChange.Right;
            }
            else
            {
                NextCrossingChange = DirectionChange.Left;
            }
        }
    }

    private enum Direction
    {
        North,
        East,
        South,
        West
    }

    private enum DirectionChange
    {
        Left,
        Straight,
        Right
    }


}