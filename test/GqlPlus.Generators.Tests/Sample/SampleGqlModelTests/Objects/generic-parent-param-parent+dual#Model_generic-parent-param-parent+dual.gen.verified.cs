﻿//HintName: Model_generic-parent-param-parent+dual.gen.cs
// Generated from generic-parent-param-parent+dual.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_parent_dual;

public interface IDualGnrcPrntParamPrnt
  : IRefDualGnrcPrntParamPrnt
{
}
public class DualDualGnrcPrntParamPrnt
  : DualRefDualGnrcPrntParamPrnt
  , IDualGnrcPrntParamPrnt
{
}

public interface IRefDualGnrcPrntParamPrnt<Tref>
  : Iref
{
}
public class DualRefDualGnrcPrntParamPrnt<Tref>
  : Dualref
  , IRefDualGnrcPrntParamPrnt<Tref>
{
}

public interface IAltDualGnrcPrntParamPrnt
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltDualGnrcPrntParamPrnt
  : IAltDualGnrcPrntParamPrnt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
