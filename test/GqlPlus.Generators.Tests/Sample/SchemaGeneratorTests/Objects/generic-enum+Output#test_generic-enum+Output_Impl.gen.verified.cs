﻿//HintName: test_generic-enum+Output_Impl.gen.cs
// Generated from generic-enum+Output.graphql+ for Impl

/*
*/
namespace GqlPlus.GeneratorTests.Gqlp_generic_enum_Output;

public class OutputtestGnrcEnumOutp
  : ItestGnrcEnumOutp
{
  public RefGnrcEnumOutp<EnumGnrcEnumOutp> AsRefGnrcEnumOutp { get; set; }
}

public class OutputtestRefGnrcEnumOutp<Ttype>
  : ItestRefGnrcEnumOutp<Ttype>
{
  public Ttype field { get; set; }
}
