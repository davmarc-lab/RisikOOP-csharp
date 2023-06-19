global using Microsoft.VisualStudio.TestTools.UnitTesting;
using RisikOOPSolution.Model;

Territory t1 = new Territory("Primo", 0);
Territory t2 = new Territory("Secondo", 0);

Combat c = new Combat(t1, 1, t2, 2);

var res = c.attack(2, 2);

