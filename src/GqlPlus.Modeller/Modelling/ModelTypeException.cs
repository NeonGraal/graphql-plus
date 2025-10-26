﻿using System.Diagnostics.CodeAnalysis;

namespace GqlPlus.Modelling;

public class ModelTypeException<TModel>
  : ModelException
{
  private static string ModelTypeMessage(object? type)
    => $"Type '{type?.GetType().TidyTypeName().IfWhiteSpace("null")}' Model is not '{typeof(TModel).TidyTypeName()}'";

  public ModelTypeException(object? type)
    : base(ModelTypeMessage(type))
  { }

  public ModelTypeException()
  { }

  public ModelTypeException(string message)
    : base(message)
  { }

  [ExcludeFromCodeCoverage]
  public ModelTypeException(string message, Exception innerException)
    : base(message, innerException)
  { }
}
