//HintName: test_generic-parent-param-parent+Input_Intf.gen.cs
// Generated from generic-parent-param-parent+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_parent_param_parent_Input;

public interface ItestGnrcPrntParamPrntInp
  : ItestRefGnrcPrntParamPrntInp<ItestAltGnrcPrntParamPrntInp>
{
  ItestGnrcPrntParamPrntInpObject AsGnrcPrntParamPrntInp { get; }
}

public interface ItestGnrcPrntParamPrntInpObject
  : ItestRefGnrcPrntParamPrntInpObject<ItestAltGnrcPrntParamPrntInp>
{
}

public interface ItestRefGnrcPrntParamPrntInp<TRef>
{
  TRef AsParent { get; }
  ItestRefGnrcPrntParamPrntInpObject<TRef> AsRefGnrcPrntParamPrntInp { get; }
}

public interface ItestRefGnrcPrntParamPrntInpObject<TRef>
{
}

public interface ItestAltGnrcPrntParamPrntInp
{
  string AsString { get; }
  ItestAltGnrcPrntParamPrntInpObject AsAltGnrcPrntParamPrntInp { get; }
}

public interface ItestAltGnrcPrntParamPrntInpObject
{
  decimal Alt { get; }
}
