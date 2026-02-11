//HintName: test_parent-field+Input_Intf.gen.cs
// Generated from parent-field+Input.graphql+ for Intf
/*
*/

namespace GqlPlus.GeneratorTests.Gqlp_parent_field_Input;

public interface ItestPrntFieldInp
  : ItestRefPrntFieldInp
{
  ItestPrntFieldInpObject AsPrntFieldInp { get; }
}

public interface ItestPrntFieldInpObject
  : ItestRefPrntFieldInpObject
{
  decimal Field { get; }
}

public interface ItestRefPrntFieldInp
{
  string AsString { get; }
  ItestRefPrntFieldInpObject AsRefPrntFieldInp { get; }
}

public interface ItestRefPrntFieldInpObject
{
  decimal Parent { get; }
}
