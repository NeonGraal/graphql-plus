//HintName: Model_generic-parent-param+Dual.gen.cs
// Generated from generic-parent-param+Dual.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_generic_parent_param_Dual;

public interface IGnrcPrntParamDual
  : IRefGnrcPrntParamDual
{
}
public class DualGnrcPrntParamDual
  : DualRefGnrcPrntParamDual
  , IGnrcPrntParamDual
{
}

public interface IRefGnrcPrntParamDual<Tref>
{
  Tref Asref { get; }
}
public class DualRefGnrcPrntParamDual<Tref>
  : IRefGnrcPrntParamDual<Tref>
{
  public Tref Asref { get; set; }
}

public interface IAltGnrcPrntParamDual
{
  Number alt { get; }
  String AsString { get; }
}
public class DualAltGnrcPrntParamDual
  : IAltGnrcPrntParamDual
{
  public Number alt { get; set; }
  public String AsString { get; set; }
}
