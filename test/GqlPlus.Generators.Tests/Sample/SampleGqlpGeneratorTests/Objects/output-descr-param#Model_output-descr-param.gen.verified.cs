﻿//HintName: Model_output-descr-param.gen.cs
// Generated from output-descr-param.graphql+

/*
*/

namespace GqlPlus.GqlpGeneratorSchemaTests.Model_output_descr_param;

public interface IOutpDescrParam
{
  FldOutpDescrParam field { get; }
}
public class OutputOutpDescrParam
  : IOutpDescrParam
{
  public FldOutpDescrParam field { get; set; }
}

public interface IFldOutpDescrParam
{
}
public class DualFldOutpDescrParam
  : IFldOutpDescrParam
{
}

public interface IInOutpDescrParam
{
  Number param { get; }
  String AsString { get; }
}
public class InputInOutpDescrParam
  : IInOutpDescrParam
{
  public Number param { get; set; }
  public String AsString { get; set; }
}
