﻿//HintName: Model_constraint-parent-dual-grandparent+Output.gen.cs
// Generated from constraint-parent-dual-grandparent+Output.graphql+

/*
*/

namespace GqlTest.Model_constraint_parent_dual_grandparent_Output;

public interface ICnstPrntDualGrndOutp
  : IRefCnstPrntDualGrndOutp
{
}
public class OutputCnstPrntDualGrndOutp
  : OutputRefCnstPrntDualGrndOutp
  , ICnstPrntDualGrndOutp
{
}

public interface IRefCnstPrntDualGrndOutp<Tref>
  : Iref
{
}
public class OutputRefCnstPrntDualGrndOutp<Tref>
  : Outputref
  , IRefCnstPrntDualGrndOutp<Tref>
{
}

public interface IGrndCnstPrntDualGrndOutp
{
  String AsString { get; }
}
public class DualGrndCnstPrntDualGrndOutp
  : IGrndCnstPrntDualGrndOutp
{
  public String AsString { get; set; }
}

public interface IPrntCnstPrntDualGrndOutp
  : IGrndCnstPrntDualGrndOutp
{
}
public class DualPrntCnstPrntDualGrndOutp
  : DualGrndCnstPrntDualGrndOutp
  , IPrntCnstPrntDualGrndOutp
{
}

public interface IAltCnstPrntDualGrndOutp
  : IPrntCnstPrntDualGrndOutp
{
  Number alt { get; }
}
public class OutputAltCnstPrntDualGrndOutp
  : OutputPrntCnstPrntDualGrndOutp
  , IAltCnstPrntDualGrndOutp
{
  public Number alt { get; set; }
}
