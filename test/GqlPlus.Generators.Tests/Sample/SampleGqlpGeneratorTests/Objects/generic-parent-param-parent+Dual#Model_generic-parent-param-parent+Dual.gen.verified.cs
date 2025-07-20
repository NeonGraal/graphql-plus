//HintName: Model_generic-parent-param-parent+Dual.gen.cs
// Generated from generic-parent-param-parent+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_parent_param_parent_Dual;

public interface IGnrcPrntParamPrntDual
  : IRefGnrcPrntParamPrntDual
{
}
public class DualGnrcPrntParamPrntDual
  : DualRefGnrcPrntParamPrntDual
  , IGnrcPrntParamPrntDual
{
}

public interface IRefGnrcPrntParamPrntDual<Tref>
  : Iref
{
}
public class DualRefGnrcPrntParamPrntDual<Tref>
  : Dualref
  , IRefGnrcPrntParamPrntDual<Tref>
{
}

public interface IAltGnrcPrntParamPrntDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcPrntParamPrntDual
  : IAltGnrcPrntParamPrntDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
