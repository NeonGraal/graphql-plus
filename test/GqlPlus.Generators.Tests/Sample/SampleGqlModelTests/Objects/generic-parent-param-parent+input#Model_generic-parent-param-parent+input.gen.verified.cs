﻿//HintName: Model_generic-parent-param-parent+input.gen.cs
// Generated from generic-parent-param-parent+input.graphql+

/*
*/

namespace GqlTest.Model_generic_parent_param_parent_input;

public interface IInpGnrcPrntParamPrnt
  : IRefInpGnrcPrntParamPrnt
{
}
public class InputInpGnrcPrntParamPrnt
  : InputRefInpGnrcPrntParamPrnt
  , IInpGnrcPrntParamPrnt
{
}

public interface IRefInpGnrcPrntParamPrnt<Tref>
  : Iref
{
}
public class InputRefInpGnrcPrntParamPrnt<Tref>
  : Inputref
  , IRefInpGnrcPrntParamPrnt<Tref>
{
}

public interface IAltInpGnrcPrntParamPrnt
{
  Number alt { get; }
  String AsString { get; }
}
public class InputAltInpGnrcPrntParamPrnt
  : IAltInpGnrcPrntParamPrnt
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
