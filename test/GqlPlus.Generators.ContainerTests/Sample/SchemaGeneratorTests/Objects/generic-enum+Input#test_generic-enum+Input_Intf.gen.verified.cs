//HintName: test_generic-enum+Input_Intf.gen.cs
// Generated from generic-enum+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Input;

public interface ItestGnrcEnumInp
{
  ItestRefGnrcEnumInp<testEnumGnrcEnumInp> AsRefGnrcEnumInp { get; }
  ItestGnrcEnumInpObject AsGnrcEnumInp { get; }
}

public interface ItestGnrcEnumInpObject
{
}

public interface ItestRefGnrcEnumInp<TType>
{
  ItestRefGnrcEnumInpObject AsRefGnrcEnumInp { get; }
}

public interface ItestRefGnrcEnumInpObject<TType>
{
  TType Field { get; }
}
