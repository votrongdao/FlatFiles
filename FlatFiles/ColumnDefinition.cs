﻿using System;
using FlatFiles.Properties;

namespace FlatFiles
{
    /// <summary>
    /// Defines a column that is part of a record schema.
    /// </summary>
    public abstract class ColumnDefinition
    {
        private string columnName;

        /// <summary>
        /// Initializes a new instance of a ColumnDefinition.
        /// </summary>
        /// <param name="columnName">The name of the column to define.</param>
        protected ColumnDefinition(string columnName)
        {
            ColumnName = columnName;
        }

        /// <summary>
        /// Gets the name of the column.
        /// </summary>
        public string ColumnName
        {
            get 
            { 
                return columnName; 
            }
            internal set 
            {
                if (value != null)
                {
                    value = value.Trim();
                }
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(Resources.BlankColumnName);
                }
                columnName = value.ToLowerInvariant();
            }
        }

        /// <summary>
        /// Gets the type of the values in the column.
        /// </summary>
        public abstract Type ColumnType { get; }

        /// <summary>
        /// Parses the given value and returns the parsed object.
        /// </summary>
        /// <param name="value">The value to parse.</param>
        /// <returns>The parsed value.</returns>
        public abstract object Parse(string value);

        /// <summary>
        /// Formats the given object.
        /// </summary>
        /// <param name="value">The object to format.</param>
        /// <returns>The formatted value.</returns>
        public abstract string Format(object value);
    }
}
