﻿// Copyright (c) The Perspex Project. All rights reserved.
// Licensed under the MIT license. See licence.md file in the project root for full license information.

using System;
using System.Linq;
using Perspex.Controls.Mixins;
using Perspex.Controls.Presenters;

namespace Perspex.Controls.Primitives
{
    /// <summary>
    /// Represents an <see cref="ItemsControl"/> with a related header.
    /// </summary>
    public class HeaderedItemsControl : ItemsControl
    {
        /// <summary>
        /// Defines the <see cref="Header"/> property.
        /// </summary>
        public static readonly PerspexProperty<object> HeaderProperty =
            HeaderedContentControl.HeaderProperty.AddOwner<HeaderedItemsControl>();

        /// <summary>
        /// Initializes static members of the <see cref="ContentControl"/> class.
        /// </summary>
        static HeaderedItemsControl()
        {
            ContentControlMixin.Attach<HeaderedItemsControl>(
                HeaderProperty,
                x => x.LogicalChildren,
                "PART_HeaderPresenter");
        }

        /// <summary>
        /// Gets or sets the content of the control's header.
        /// </summary>
        public object Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        /// <summary>
        /// Gets the header presenter from the control's template.
        /// </summary>
        public ContentPresenter HeaderPresenter
        {
            get;
            private set;
        }

        /// <inheritdoc/>
        protected override void OnTemplateApplied(TemplateAppliedEventArgs e)
        {
            base.OnTemplateApplied(e);
            HeaderPresenter = e.NameScope.Find<ContentPresenter>("PART_HeaderPresenter");
        }
    }
}
